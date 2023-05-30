using System.Collections.Generic;
using UnityEngine;

public class Inventory_Old : MonoBehaviour
{
    [SerializeField] List<InventorySlot> inventorySlotList;
    public Inventory_Old()
    {
        inventorySlotList = new List<InventorySlot>();
    }
    public void PickUpItem(Item_Old item)
    {
        AddItem(item.item, item.quantity);
        item.PickUpItem();
    }
    public void AddItem(ItemType item, int quantity)
    {
        InventorySlot newInventorySlot = GetInventorySlot(item, quantity);
        if (inventorySlotList.Contains(newInventorySlot))
        {
            newInventorySlot.AddToItemQuantity(quantity);
            return;
        }
        AddNewSlot(newInventorySlot);
        Debug.Log($"Inventory : {inventorySlotList.Count}");
    }

    private void AddNewSlot(InventorySlot newInventorySlot)
    {
        inventorySlotList.Add(newInventorySlot);
    }

    public InventorySlot GetInventorySlot(ItemType item, int quantity)
    {
        foreach (InventorySlot slot in inventorySlotList)
        {
            if (slot.item == item)
            {
                return slot;
            }
        }
        return new InventorySlot(item, quantity);
    }
    public List<InventorySlot> GetItemList()
    {
        return inventorySlotList;
    }
    public Item_Old GetItem(ItemType type)
    {
        foreach (InventorySlot slot in inventorySlotList)
        {

        }
        return null;
    }
}
