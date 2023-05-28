namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        bool StoreItem(IAmAnItem item);
        void RemoveItem(IAmAnItem item);
    }
}

