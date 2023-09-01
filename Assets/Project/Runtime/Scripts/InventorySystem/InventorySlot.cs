using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] ItemType itemType;
        [SerializeField] int quantity = 0;
        public InventorySlot(ItemType item, int quantity = 0)
        {
            this.itemType = item;
            this.quantity = quantity;
        }

        public string ItemName() => itemType.itemName;
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

