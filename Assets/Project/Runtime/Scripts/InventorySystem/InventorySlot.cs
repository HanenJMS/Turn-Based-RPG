using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] Item item;
        [SerializeField] int quantity = 0;
        public InventorySlot(Item item, int quantity = 0)
        {
            this.item = item;
            this.quantity = quantity;
        }

        public string ItemName() => item.ItemType().itemName;
        public IAmAnItem Item() => item;
        public int Quantity() => quantity;
        public void AddToItemQuantity(int quantity)
        {
            this.quantity += quantity;
        }
        public void RemoveToItemQuantity(int quantity)
        {
            this.quantity -= quantity;
        }
    }
}

