using System;

namespace Archero.Character.Player
{
    public class Inventory
    {
        private int _goldAmount;

        public event Action<int> OnInventoryChanged;

        public void AddToInventory(int amount)
        {
            _goldAmount += amount;
            
            OnInventoryChanged?.Invoke(_goldAmount);
        }
    }
}