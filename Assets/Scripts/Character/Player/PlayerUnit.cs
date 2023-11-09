using System.Collections.Generic;
using Archero.Components;
using Archero.Definitions;
using Archero.Utils;
using DG.Tweening;
using UnityEngine;

namespace Archero.Character.Player
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    public class PlayerUnit : Unit
    {
        [SerializeField] private PlayerDefinition _playerDefinition;     
        [SerializeField] private float _attackRange;
        
        private List<Transform> _enemiesTransform = new();
        public Inventory Inventory { get; } = new();
        
        public List<Transform> EnemiesTransform => _enemiesTransform;
        public PlayerMovementComponent MovementComponent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            SetupComponents();
        }

        protected override void SetupComponents()
        {
            base.SetupComponents();
            AttackCooldown = new Timer {Value = 1f / _playerDefinition.AttackSpeed};
            MovementComponent = GetComponent<PlayerMovementComponent>();
            
            MovementComponent.Setup(_playerDefinition.MoveSpeed, CachedTransform);
            HealthComponent.Setup(_playerDefinition.Hp);
            AttackComponent.Setup(CachedTransform, _playerDefinition.AttackDamage);
        }

        private void Update()
        {
            if (MovementComponent.Direction.magnitude == 0)
            {
               Attack();
            }
        }

        private void Attack()
        {
            if (!AttackCooldown.IsReady) return;

            if (!TryGetClosestEnemy(out var closestTransform)) return;
            
            Vector3 lookAt = new Vector3(closestTransform.position.x, CachedTransform.position.y, closestTransform.position.z);
            CachedTransform.DOLookAt(lookAt, .1f)
                .OnPlay(() => AttackCooldown.Reset())
                .OnComplete(() =>
            {
                AttackComponent.SetTarget(closestTransform);
                AttackComponent.Attack();
            });
        }

        private bool TryGetClosestEnemy(out Transform closestTransform)
        {
            closestTransform = null;
            if (_enemiesTransform.Count == 0) return false;
            float currentClosestEnemyDistance = 0;
            foreach (var enemyTransform in _enemiesTransform)
            {
                if (!AttackComponent.IsTargetInView(enemyTransform))
                {
                    continue;
                }
                float distanceToTarget = (enemyTransform.position - CachedTransform.position).magnitude;
                
                if (closestTransform == null)
                {
                    closestTransform = enemyTransform;
                    currentClosestEnemyDistance = distanceToTarget;
                    continue;
                }

                if (distanceToTarget < currentClosestEnemyDistance)
                {
                    currentClosestEnemyDistance = distanceToTarget;
                    closestTransform = enemyTransform;
                }
            }

            return closestTransform != null && currentClosestEnemyDistance <= _attackRange;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ICollectable>(out var collectable))
            {
                collectable.Collect(Inventory);
            }
        }
    }
}