using RPGSandBox.InteractableSystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventorySlot
    {
        ItemData GetItemType();
        void AddToItemQuantity(int itemTransferringQuantity);
        void RemoveFromItemQuantity(int itemTransferringQuantity);
        int Quantity();
    }
}
