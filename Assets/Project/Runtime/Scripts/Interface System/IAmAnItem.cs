namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        ItemType ItemType();
        int QuantityIs();
        int ItemQualityIs();
        void AddingQuantity(int quantity);
        
        IAmAnItem PickUpItem();
        bool ItemHasAnOwner();
    }
}

