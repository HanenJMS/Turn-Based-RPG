[System.Serializable]
public class InventorySlot_Old
{
    public ItemType item;
    public int quantity;
    public InventorySlot_Old(ItemType item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
    public void AddToItemQuantity(int quantity)
    {
        this.quantity += quantity;
    }
}
