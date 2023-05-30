namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        bool Storing(IAmAnItem item);
        void RemoveItem(IAmAnItem item);
    }
}

