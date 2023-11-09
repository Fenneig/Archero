using Archero.Character.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Archero.UI
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField] private Image _currentHealthImage;

        [Inject]
        private void Construct(PlayerUnit playerUnit)
        {
            //TODO: dispose somehow? 
            playerUnit.HealthComponent.OnDamaged += HealthComponentOnOnDamaged;
        }
        
        private void HealthComponentOnOnDamaged(float newHealth)
        {
            _currentHealthImage.fillAmount = newHealth;
        }
    }
}