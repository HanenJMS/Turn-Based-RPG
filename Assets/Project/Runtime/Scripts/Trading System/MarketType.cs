using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.TradingSystem
{
    public abstract class MarketType
    {
        [SerializeField] Inventory inventory = new();
        [SerializeField] int inventoryCountLimiter = 10000;
        private void Start()
        {
            inventory.SetInventoryCount(inventoryCountLimiter);
        }
        public Inventory Inventory()
        {
            return inventory;
        }
        public void SetInventoryCountLimiter(int CountLimiter)
        {
            inventoryCountLimiter = CountLimiter;
        }
        //public bool AddToTrade(InventorySlot trade)
        //{
        //    return inventory.AddToInventory(trade);
        //}
        //public bool RemoveFromTrade(InventorySlot trade)
        //{
        //    return inventory.RemoveFromInventory(trade);
        //}
        //public abstract bool CanTrade(InventorySlot trade);
    }
}

