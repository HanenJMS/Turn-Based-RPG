using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    public class Inventory : MonoBehaviour, IHaveAnInventory
    {
        [SerializeField] List<IAmAnItem> inventory = new List<IAmAnItem>();
        public bool Storing(IAmAnItem item)
        {
            if (item == null) return false;
            inventory.Add(item.PickUpItem());
            Debug.Log($"Inventory count: {inventory.Count}");
            return true;
        }
        public void RemoveItem(IAmAnItem item)
        {
            inventory.Remove(item);
        }
    }
}

