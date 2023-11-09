using Archero.Character.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Archero.UI
{
    public class MoneyWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        [Inject]
        private void Construct(PlayerUnit playerUnit)
        {
            playerUnit.Inventory.OnInventoryChanged += InventoryOnOnInventoryChanged;
        }

        private void InventoryOnOnInventoryChanged(int newValue)
        {
            _goldText.text = newValue.ToString();
        }
    }
}