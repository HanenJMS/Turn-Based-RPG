using RPGSandBox.InventorySystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventory
    {
        bool Checking(IAmAnItem item);
        void Removing(IAmAnItem item);
        void Storing(IAmAnItem item);
    }
}

