using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    public class Inventory : MonoBehaviour, IHaveAnInventory
    {
        List<IAmAnItem> inventory = new List<IAmAnItem>();



        public void StoreItem(IAmAnItem item)
        {
            inventory.Add(item);
        }
        public void RemoveItem(IAmAnItem item)
        {
            inventory.Remove(item);
        }
    }
}

