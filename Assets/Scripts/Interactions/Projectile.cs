using System;
using Archero.Character;
using Archero.Systems.Pause;
using UnityEngine;

namespace Archero.Interactions
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour, IPauseHandler
    {
        private Rigidbody _rigidbody;
        private int _damage;
        private float _projectileSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            PauseService.I.Register(this);
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<HealthComponent>(out var targetHealth))
                targetHealth.ApplyDamage(_damage);
            
            Destroy(gameObject);
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                _rigidbody.constraints = RigidbodyConstraints.None;
                _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        private void OnDestroy()
        {
            PauseService.I.UnRegister(this);
        }
    }
}