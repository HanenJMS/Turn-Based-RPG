using RPGSandBox.InventorySystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnInventory
    {
        void Storing(IAmAnItem item);
        void Removing(IAmAnItem item, int qty);
        bool Checking(IAmAnItem item, int qty);
        IHaveAnInventory GetInventoryList();
        List<InventorySlot> GetInventorySlots();
    }
}

