using Archero.Character;
using UnityEngine;

namespace Archero.Interactions
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private int _damage;
        private float _projectileSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Setup(int damage, float projectileSpeed)
        {
            _damage = damage;
            _projectileSpeed = projectileSpeed;
        }

        public void ShootInDirection(Vector3 direction)
        {
            _rigidbody.AddForce(direction.normalized * _projectileSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<HealthComponent>(out var targetHealth))
                targetHealth.ApplyDamage(_damage);

            DestroyObject();
        }

        private void OnCollisionEnter(Collision other)
        {
            DestroyObject();
        }

        private void DestroyObject() => Destroy(gameObject);
    }
}