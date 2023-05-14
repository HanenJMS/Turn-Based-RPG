[System.Serializable]
public class InventorySlot
{
    public ItemSO item;
    public int quantity;
    public InventorySlot(ItemSO item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
    public void AddToItemQuantity(int quantity)
    {
        this.quantity += quantity;
    }
}
