using RPGSandBox.InventorySystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventorySlot
    {
        ItemType GetItemType();
        void AddToItemQuantity(int itemTransferringQuantity);
        void RemoveFromItemQuantity(int itemTransferringQuantity);
        int Quantity();
    }
}
