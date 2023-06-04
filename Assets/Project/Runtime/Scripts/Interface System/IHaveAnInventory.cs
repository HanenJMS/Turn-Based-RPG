namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        void Storing(IAmAnItem item);
        void RemoveItem(IAmAnItem item);
        bool Checking(IAmAnItem item, int qty);
    }
}

