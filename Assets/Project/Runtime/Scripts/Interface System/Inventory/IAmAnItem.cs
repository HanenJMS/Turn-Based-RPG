using RPGSandBox.InventorySystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        ItemType ItemType();
        IAmAnItem PickUpItem();
        Item GetItem();
    }
}

