using RPGSandBox.InventorySystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventory
    {
        void Storing(IAmAnItem item);
        void Removing(IAmAnItem item, int qty);
        bool Checking(IAmAnItem item, int qty);
        IAmAnInventory GetInventoryList();
        List<InventorySlot> GetInventorySlots();
    }
}

