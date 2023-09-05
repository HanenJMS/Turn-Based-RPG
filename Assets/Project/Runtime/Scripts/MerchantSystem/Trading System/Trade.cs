using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.MerchantSystem
{
    public abstract class Trade : MonoBehaviour
    {
        public Inventory inventory;
        void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
    }
}

