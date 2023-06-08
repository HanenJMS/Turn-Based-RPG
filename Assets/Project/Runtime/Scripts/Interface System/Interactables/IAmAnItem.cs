namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        ItemType ItemType();
        int GetQuantity();
        int GetQuality();
        void AddingQuantity(int quantity);
        void RemovingQuantity(int quantity);
        IAmAnItem PickUpItem();
        bool ItemHasAnOwner();
    }
}

