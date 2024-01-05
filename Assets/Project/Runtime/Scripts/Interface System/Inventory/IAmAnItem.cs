using RPGSandBox.InteractableSystem;
using RPGSandBox.InventorySystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        IAmAnItem PickUpItem();
        ItemData ItemType();
        InventorySlot GetItemWorldInventorySlot();
    }
}

