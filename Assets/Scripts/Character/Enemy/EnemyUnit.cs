using Archero.Character.Enemy.States;
using Archero.Character.Player;
using Archero.Components;
using Archero.Definitions;
using Archero.Utils;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Archero.Character.Enemy
{
    [RequireComponent(typeof(EnemyMovementComponent))]
    public class EnemyUnit : Unit
    {
        [Header("Behaviour states"), Space]
        [SerializeField] private AttackState _attackState;
        [SerializeField] private ChasePlayerState _chasePlayerState;
        [SerializeField] private IdleState _idleState;
        [Header("Definition"), Space] 
        [SerializeField] private EnemyDefinition _enemyDefinition;
        [SerializeField, Min(0)] private float _attackPrepareRange;
        [SerializeField, Min(0)] private float _attackRange;
        [Header("Collide damage"), Space]
        [SerializeField, Min(0)] private int _collideDamage;
        [SerializeField] private Timer _collideDamageCooldown;
        [Header("Inventory")]
        [SerializeField] private GoldCoin _carryItem;
        [SerializeField, Range(1, 5)] private int _minCoins;
        [SerializeField, Range(1, 5)] private int _maxCoins;
        
        private BehaviourState _currentState;
        public Transform TargetTransform { get; private set; }
        public EnemyMovementComponent MovementComponent { get; private set; }
        public Timer IdleTimer => _enemyDefinition.IdleTimer;
        private float DistanceToTarget => TargetTransform == null ? 0 : (CachedTransform.position - TargetTransform.position).magnitude;

        [Inject]
        private void Construct(PlayerUnit playerUnit)
        {
            TargetTransform = playerUnit.CachedTransform;
        }

        protected override void Awake()
        {
            base.Awake();
            SetupComponents();
            SetState(_idleState);
        }

        protected override void SetupComponents()
        {
            base.SetupComponents();
            AttackCooldown = new Timer {Value = 1f / _enemyDefinition.AttackSpeed};
            MovementComponent = GetComponent<EnemyMovementComponent>();
            
            MovementComponent.Setup(_enemyDefinition.MoveSpeed, CachedTransform);
            AttackComponent.Setup(CachedTransform, _enemyDefinition.AttackDamage);
            AttackComponent.SetTarget(TargetTransform);
            HealthComponent.Setup(_enemyDefinition.Hp);
        }

        private void OnValidate()
        {
            if (_minCoins > _maxCoins) _maxCoins = _minCoins;
        }

        private void Update()
        {
            if (!_currentState.IsFinished)
            {
                _currentState.OnUpdate();
            }
            else
            {
                if (AttackCooldown.IsReady && _attackRange >= DistanceToTarget && AttackComponent.IsTargetInView())
                {
                    SetState(_attackState);
                }
                else if (_attackRange < DistanceToTarget || !AttackComponent.IsTargetInView())
                {
                    SetState(_chasePlayerState);
                }
            }
        }

        private void SetState(BehaviourState state)
        {
            _currentState = Instantiate(state);
            _currentState.StateOwner = this;
            _currentState.Init();
        }
        
        public bool IsReadyForAttack() => 
            DistanceToTarget <= _attackPrepareRange && AttackComponent.IsTargetInView();

        public void Attack()
        {
            Vector3 lookAt = new Vector3(TargetTransform.position.x, CachedTransform.position.y, TargetTransform.position.z);

            var tween = CachedTransform.DOLookAt(lookAt, .1f)
                .OnPlay(() => AttackCooldown.Reset())
                .OnComplete(() =>
                {
                    AttackComponent.Attack();
                    _currentState.EarlyComplete();
                });
            ActiveTweens.Add(tween);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_collideDamageCooldown.IsReady) return;

            if (!other.gameObject.TryGetComponent<PlayerUnit>(out var player)) return;
            
            player.HealthComponent.ApplyDamage(_collideDamage);
            _collideDamageCooldown.Reset();
        }

        protected override void Die()
        {
            if (_carryItem != null)
            {
                GoldCoin goldCoin = Instantiate(_carryItem, CachedTransform.position, _carryItem.transform.rotation);
                goldCoin.Setup(Random.Range(_minCoins, _maxCoins));
            }

            base.Die();
        }
    }
}