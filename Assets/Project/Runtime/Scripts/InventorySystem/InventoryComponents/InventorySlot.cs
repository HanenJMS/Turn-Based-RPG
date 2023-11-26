using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class InventorySlot :  IAmAnInventorySlot
    {
        [SerializeField] ItemType itemType;
        [SerializeField] int quantity = 0;
        public InventorySlot(ItemType item, int quantity = 1)
        {
            this.itemType = item;
            this.quantity = quantity;
        }

        public string ItemName() => itemType.name;
        public ItemType GetItemType() => itemType;
        public int Quantity() => quantity;
        public void AddToItemQuantity(int quantity)
        {
            this.quantity += quantity;
        }
        public void RemoveFromItemQuantity(int quantity)
        {
            this.quantity -= quantity;
        }
    }
}

