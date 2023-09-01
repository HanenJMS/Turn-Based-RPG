using RPGSandBox.InventorySystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        IAmAnItem PickUpItem();
        ItemType ItemType();
        InventorySlot GetItemWorldInventorySlot();
    }
}

