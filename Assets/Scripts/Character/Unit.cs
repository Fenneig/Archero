using System.Collections.Generic;
using Archero.Character.Components;
using Archero.Interactions;
using Archero.Systems.Pause;
using Archero.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Archero.Character
{
    [RequireComponent(typeof(AttackComponent))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    public class Unit : MonoBehaviour, IDamagable, IPauseHandler
    {
        private NavMeshAgent _navMeshAgent;
        private Rigidbody _rigidbody;
        protected List<Tween> ActiveTweens = new();
        
        public Transform CachedTransform { get; private set; }
        public HealthComponent HealthComponent { get; private set; }
        protected AttackComponent AttackComponent { get; private set; }
        protected Timer AttackCooldown { get; set; }
        
        protected bool IsPaused { get; private set; } 
        
        protected virtual void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();
            CachedTransform = transform;
            PauseService.I.Register(this);
        }

        protected virtual void SetupComponents()
        {
            HealthComponent = GetComponent<HealthComponent>();
            AttackComponent = GetComponent<AttackComponent>();

            HealthComponent.OnDied += Die;
        }

        public void Damage(int amount)
        {
            HealthComponent.ApplyDamage(amount);
        }

        protected virtual void Die()
        {
            ActiveTweens.ForEach(tween => tween?.Kill());
            Destroy(gameObject);
        }

        public virtual void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;
            _navMeshAgent.isStopped = isPaused;
            if (isPaused) _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            else _rigidbody.constraints = RigidbodyConstraints.None;
        }

        private void OnDestroy()
        {
            PauseService.I.UnRegister(this);
        }
    }
}