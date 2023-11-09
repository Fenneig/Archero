using Archero.Character.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Archero.UI
{
    public class EnemyHealthWidget : MonoBehaviour
    {
        [SerializeField] private EnemyUnit _enemyUnit;
        [SerializeField] private Image _currentHealthImage;
        
        private void Start()
        {
            _enemyUnit.HealthComponent.OnDamaged += HealthComponentOnOnDamaged;
        }

        private void HealthComponentOnOnDamaged(float newHealth)
        {
            _currentHealthImage.fillAmount = newHealth;
        }

        private void OnDestroy()
        {
            _enemyUnit.HealthComponent.OnDamaged -= HealthComponentOnOnDamaged;
        }
    }
}