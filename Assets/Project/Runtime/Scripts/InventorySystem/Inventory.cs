using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class Inventory : IAmAnInventory
    {
        [SerializeField] Dictionary<ItemType, InventorySlot> inventory = new();
        [SerializeField] List<InventorySlot> exposedInventory = new();
        [SerializeField] int currentInventoryCount = 0;
        [SerializeField] int totalInventoryCount = 5;

        //functions needed to add to interfaces
        public void SetInventoryCount(int count)
        {
            totalInventoryCount = count;
        }
        public InventorySlot GetInventorySlot(ItemType itemType)
        {
            return inventory[itemType];
        }
        public List<InventorySlot> GetInventoryList()
        {
            return exposedInventory;
        }
        public bool AddToInventory(IAmAnInventorySlot transferringSlot)
        {
            if (transferringSlot == null) return false;
            ItemType itemType = transferringSlot.GetItemType();
            int itemTransferringQuantity = transferringSlot.Quantity();
            if (itemTransferringQuantity > (totalInventoryCount - currentInventoryCount)) return false;
            if (inventory.ContainsKey(itemType))
            {
                inventory[itemType].AddToItemQuantity(itemTransferringQuantity);
                transferringSlot.RemoveFromItemQuantity(itemTransferringQuantity);
            }
            else
            {
                InventorySlot newSlot = new(itemType, itemTransferringQuantity);
                inventory.Add(itemType, newSlot);
                transferringSlot.RemoveFromItemQuantity(itemTransferringQuantity);
            }
            CalculateCurrentInventoryCount();
            return true;
        }
        public bool RemoveFromInventory(IAmAnInventorySlot transferringSlot)
        {
            if (transferringSlot == null)
            {
                Debug.Log("Did you try to give me nothing? Inventory.cs RemoveFromInventory()");
                return false;
            }
            ItemType itemType = transferringSlot.GetItemType();
            int itemTransferringQuantity = transferringSlot.Quantity();
            if (!inventory.ContainsKey(itemType))
            {
                Debug.Log("Can't give you what I don't have. Inventory.cs RemoveFromInventory()");
                return false;
            }
            if (inventory[itemType].Quantity() < itemTransferringQuantity)
            {
                Debug.Log("I don't have that many. Inventory.cs RemoveFromInventory()");
                return false;
            }
            inventory[itemType].RemoveFromItemQuantity(itemTransferringQuantity);
            transferringSlot.AddToItemQuantity(itemTransferringQuantity);
            CalculateCurrentInventoryCount();
            return true;
        }
        public bool Contains(IAmAnInventorySlot itemTradeSlot)
        {
            if (!inventory.ContainsKey(itemTradeSlot.GetItemType())) return false;
            if (inventory[itemTradeSlot.GetItemType()].Quantity() < itemTradeSlot.Quantity()) return false;
            return true;
        }
        void CalculateCurrentInventoryCount()
        {
            currentInventoryCount = 0;
            exposedInventory.Clear();
            foreach (KeyValuePair<ItemType, InventorySlot> kvp in inventory)
            {
                exposedInventory.Add(kvp.Value);
                currentInventoryCount += kvp.Value.Quantity();
            }
        }
    }
}

