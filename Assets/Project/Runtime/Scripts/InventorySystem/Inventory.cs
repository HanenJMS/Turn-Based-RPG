using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    public class Inventory : MonoBehaviour, IHaveAnInventory
    {
        //Dictionarys are currently not necessary. But just incase, Dictionary hashing system is already in place.
        //[SerializeField] Dictionary<ItemType, InventorySlot> inventory = new Dictionary<ItemType, InventorySlot>();
        [SerializeField] List<InventorySlot> inventory = new List<InventorySlot> ();
        public void Storing(IAmAnItem item)
        {
            if (item == null) return;

            InventorySlot slot = GetInventorySlot(item.PickUpItem());
            if(CheckingInventoryHas(slot))
            {
                slot.AddToItemQuantity(item.QuantityIs());
                Debug.Log($"Inventory count: {GetInventoryCount()}");
                return;
            }
            //inventory.Add(item.ItemType(), slot);
            inventory.Add(slot);
            Debug.Log($"Inventory count: {GetInventoryCount()}");
        }
        public void RemoveItem(IAmAnItem item)
        {
            //inventory.Remove(GetInventorySlot(item));
        }

        private InventorySlot GetInventorySlot(IAmAnItem item)
        {
            foreach (InventorySlot slot in inventory)
            {
                if (slot.item.ItemType() == item.ItemType())
                {
                    return slot;
                }

            }
            //if (CheckingSlotHas(item))
            //{
            //    return inventory[item.ItemType()];
            //}
            return new InventorySlot(item);
        }
        private bool CheckingInventoryHas(InventorySlot slot)
        {
            if (slot == null) return false;
            return inventory.Contains(slot);
        }
        private int GetInventoryCount()
        {
            int count = 0;
            foreach(InventorySlot slot in inventory)
            {
                count += slot.item.QuantityIs();
            }
            return count;
        }
    }
}

