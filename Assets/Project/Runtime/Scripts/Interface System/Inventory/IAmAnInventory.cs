using RPGSandBox.InventorySystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventory
    {
        bool AddToInventory(IAmAnInventorySlot itemTradeSlot);
        bool RemoveFromInventory(IAmAnInventorySlot itemTradeSlot);
        bool CheckInventory(IAmAnInventorySlot itemTradeSlot);
        List<InventorySlot> GetInventoryList();
    }
}

