using RPGSandBox.InventorySystem;
using UnityEngine;
namespace RPGSandBox.TradingSystem
{
    public abstract class MarketType
    {
        [SerializeField] Inventory inventory = new();
        public Inventory Inventory()
        {
            return inventory;
        }
    }
}

