[System.Serializable]
public class InventorySlot
{
    public ItemType item;
    public int quantity;
    public InventorySlot(ItemType item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
    public void AddToItemQuantity(int quantity)
    {
        this.quantity += quantity;
    }
}
