using RPGSandBox.InterfaceSystem;
namespace RPGSandBox.InventorySystem
{
    [System.Serializable]
    public class InventorySlot
    {
        public IAmAnItem item;
        public string itemName;
        public int quantity;
        public InventorySlot(IAmAnItem item)
        {
            this.item = item;
            this.itemName = item.ItemType().ToString();
            this.quantity = item.GetQuantity();
        }
        public void AddToItemQuantity(int quantity)
        {
            item.AddingQuantity(quantity);
            this.quantity = item.GetQuantity();
        }
        public void RemoveToItemQuantity(int quantity)
        {
            item.RemovingQuantity(quantity);
            this.quantity = item.GetQuantity();
        }
    }
}

