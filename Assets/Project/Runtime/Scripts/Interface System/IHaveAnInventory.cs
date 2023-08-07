namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        void Storing(IAmAnItem item);
        void Removing(IAmAnItem item, int qty);
        bool Checking(IAmAnItem item, int qty);
        object GetInventoryList();
    }
}

