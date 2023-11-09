using Archero.Interactions;
using Archero.Utils;
using UnityEngine;

namespace Archero.Character.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private float _projectileRadius = .05f;
        [SerializeField] private float _projectileSpeed;
        [Header("Projectile spawn position"), Space]
        [SerializeField] private Transform _attackSpawnTransform;
        [Header("Vision"), Space] 
        [SerializeField] private LayerMask _obstacleLayers;
        
        private Transform _cachedTransform;
        private Transform _targetTransform;
        private Timer _attackCooldown;
        private int _damage;

        public bool IsTargetInView() => 
            ViewHelper.IsTargetInUnitView(_cachedTransform, _targetTransform, _obstacleLayers, _projectileRadius, _attackSpawnTransform);
        public bool IsTargetInView(Transform targetTransform) => 
            ViewHelper.IsTargetInUnitView(_cachedTransform, targetTransform, _obstacleLayers, _projectileRadius, _attackSpawnTransform);

        public void Setup(Transform cachedTransform, Timer attackCooldown, int damage)
        {
            _cachedTransform = cachedTransform;
            _attackCooldown = attackCooldown;
            _damage = damage;
        }

        public void SetTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }

        public void Attack()
        {
            Projectile projectile = Instantiate(_projectilePrefab, _attackSpawnTransform.position, Quaternion.identity);
            Vector3 attackDirection = _targetTransform.position - _cachedTransform.position;
            projectile.Setup(_damage, _projectileSpeed);
            projectile.ShootInDirection(attackDirection);
            _attackCooldown.Reset();
        }
    }
}