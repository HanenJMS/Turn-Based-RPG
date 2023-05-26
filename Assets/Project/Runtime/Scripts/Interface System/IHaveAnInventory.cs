namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        void StoreItem(IAmAnItem item);
        void RemoveItem(IAmAnItem item);
    }
}

