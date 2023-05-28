namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        IAmAnItem PickUpItem();
        bool CanBePickedUp();
    }
}

