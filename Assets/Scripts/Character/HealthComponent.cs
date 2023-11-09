using System;
using UnityEngine;

namespace Archero.Character
{
    public class HealthComponent : MonoBehaviour
    {
        private int _maxHealth;
        private int _currentHealth;

        public event Action<float> OnDamaged;
        public event Action OnDied;
        
        public void Setup(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void ApplyDamage(int amount)
        {
            if (amount <= 0) return;
            _currentHealth -= amount;
            if (_currentHealth >= 0)
            {
                float healthAmountInPercent = _currentHealth / (float) _maxHealth;
                OnDamaged?.Invoke(healthAmountInPercent);
            }
            else
            {
                OnDied?.Invoke();
            }
        }
    }
}