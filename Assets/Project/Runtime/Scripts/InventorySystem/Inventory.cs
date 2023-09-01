using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    public class Inventory : MonoBehaviour, IAmAnInventory
    {
        [SerializeField] Dictionary<string, InventorySlot> inventory = new();

        [SerializeField] int currentInventoryCount = 0;
        [SerializeField] int totalInventoryCount = 5;
        public bool Checking(IAmAnItem item)
        {
            return inventory.ContainsKey(item.ItemType().itemName);
        }
        public void Removing(IAmAnItem item)
        {
            RemovingFromInventory(item.GetItemWorldInventorySlot());
        }
        public void Storing(IAmAnItem item) 
        {
            AddingToInventory(item.GetItemWorldInventorySlot());
            if(item.GetItemWorldInventorySlot().Quantity() == 0)
            {
                item.PickUpItem();
            }
        }
        void AddingToInventory(InventorySlot transferringSlot)
        {
            if (transferringSlot == null) return;
            ItemType itemType = transferringSlot.GetItemType();
            int itemTransferringQuantity = transferringSlot.Quantity();
            if (itemTransferringQuantity > (totalInventoryCount - currentInventoryCount)) return;
            if (inventory.ContainsKey(itemType.itemName))
            {
                inventory[itemType.itemName].AddToItemQuantity(itemTransferringQuantity);
                transferringSlot.RemoveFromItemQuantity(itemTransferringQuantity);
            }
            else
            {
                InventorySlot newSlot = new(itemType, itemTransferringQuantity);
                inventory.Add(itemType.itemName, newSlot);
                transferringSlot.RemoveFromItemQuantity(itemTransferringQuantity);
            }
            
            CalculateCurrentInventoryCount();
        }
        void RemovingFromInventory(InventorySlot transferringSlot)
        {
            if (transferringSlot == null)
            {
                Debug.Log("Did you try to give me nothing? Inventory.cs RemoveFromInventory()");
                return;
            }
            ItemType itemType = transferringSlot.GetItemType();
            int itemTransferringQuantity = transferringSlot.Quantity();
            if (!inventory.ContainsKey(itemType.itemName))
            {
                Debug.Log("Can't give you what I don't have. Inventory.cs RemoveFromInventory()");
                return;
            }
            if (inventory[itemType.itemName].Quantity() < itemTransferringQuantity)
            {
                Debug.Log("I don't have that many. Inventory.cs RemoveFromInventory()");
                return;
            }
            if (inventory.ContainsKey(itemType.itemName))
            {
                inventory[itemType.itemName].RemoveFromItemQuantity(itemTransferringQuantity);
                transferringSlot.AddToItemQuantity(itemTransferringQuantity);
            }
            
            CalculateCurrentInventoryCount();
        }
        void CalculateCurrentInventoryCount()
        {
            currentInventoryCount = 0;
            foreach (KeyValuePair<string, InventorySlot> kvp in inventory)
            {
                currentInventoryCount += kvp.Value.Quantity();
            }
        }
    }
}

