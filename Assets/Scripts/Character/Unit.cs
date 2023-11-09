using System.Collections.Generic;
using Archero.Character.Components;
using Archero.Interactions;
using Archero.Utils;
using DG.Tweening;
using UnityEngine;

namespace Archero.Character
{
    [RequireComponent(typeof(AttackComponent))]
    [RequireComponent(typeof(HealthComponent))]
    public class Unit : MonoBehaviour, IDamagable
    {
        protected List<Tween> ActiveTweens = new();
        
        public Transform CachedTransform { get; private set; }
        public HealthComponent HealthComponent { get; private set; }
        protected AttackComponent AttackComponent { get; private set; }
        protected Timer AttackCooldown { get; set; }


        protected virtual void Awake()
        {
            CachedTransform = transform;
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
    }
}