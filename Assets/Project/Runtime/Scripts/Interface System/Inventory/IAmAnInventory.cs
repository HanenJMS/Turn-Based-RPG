using RPGSandBox.InventorySystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnInventory
    {
        bool AddToInventory(IAmAnInventorySlot itemTradeSlot);
        bool AddToInventoryQuantity(IAmAnInventorySlot transferringSlot);
        bool RemoveFromInventoryQuantity(IAmAnInventorySlot transferringSlot);
        bool RemoveFromInventory(IAmAnInventorySlot itemTradeSlot);

        bool Contains(IAmAnInventorySlot itemTradeSlot);
        InventorySlot GetInventorySlot(ItemType itemType);
        List<InventorySlot> GetInventoryList();
    }
}

