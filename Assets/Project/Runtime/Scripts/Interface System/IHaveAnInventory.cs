namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        void Storing(IAmInteractable item);
        void Removing(IAmInteractable item, int qty);
        bool Checking(IAmInteractable item, int qty);
    }
}

