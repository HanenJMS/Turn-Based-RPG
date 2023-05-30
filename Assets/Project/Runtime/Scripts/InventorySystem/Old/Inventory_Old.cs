using System.Collections.Generic;
using UnityEngine;

public class Inventory_Old : MonoBehaviour
{
    [SerializeField] List<InventorySlot_Old> inventorySlotList;
    public Inventory_Old()
    {
        inventorySlotList = new List<InventorySlot_Old>();
    }
    public void PickUpItem(Item_Old item)
    {
        AddItem(item.item, item.quantity);
        item.PickUpItem();
    }
    public void AddItem(ItemType item, int quantity)
    {
        InventorySlot_Old newInventorySlot = GetInventorySlot(item, quantity);
        if (inventorySlotList.Contains(newInventorySlot))
        {
            newInventorySlot.AddToItemQuantity(quantity);
            return;
        }
        AddNewSlot(newInventorySlot);
        Debug.Log($"Inventory : {inventorySlotList.Count}");
    }

    private void AddNewSlot(InventorySlot_Old newInventorySlot)
    {
        inventorySlotList.Add(newInventorySlot);
    }

    public InventorySlot_Old GetInventorySlot(ItemType item, int quantity)
    {
        foreach (InventorySlot_Old slot in inventorySlotList)
        {
            if (slot.item == item)
            {
                return slot;
            }
        }
        return new InventorySlot_Old(item, quantity);
    }
    public List<InventorySlot_Old> GetItemList()
    {
        return inventorySlotList;
    }
    public Item_Old GetItem(ItemType type)
    {
        foreach (InventorySlot_Old slot in inventorySlotList)
        {

        }
        return null;
    }
}
