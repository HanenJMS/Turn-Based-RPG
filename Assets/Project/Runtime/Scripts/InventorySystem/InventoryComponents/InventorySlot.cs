using RPGSandBox.InteractableSystem;
using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class InventorySlot :  IAmAnInventorySlot
    {
        [SerializeField] ItemData itemType;
        [SerializeField] int quantity = 0;
        public InventorySlot(ItemData item, int quantity = 1)
        {
            this.itemType = item;
            this.quantity = quantity;
        }

        public string ItemName() => itemType.name;
        public ItemData GetItemType() => itemType;
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

