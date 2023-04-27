using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<InventorySlot> inventorySlotList;
    public Inventory()
    {
        inventorySlotList = new List<InventorySlot>();
    }
    public void PickUpItem(Item item)
    {
        AddItem(item.item, item.quantity);
        item.PickUpItem();
    }
    public void AddItem(ItemSO item, int quantity)
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

    public InventorySlot GetInventorySlot(ItemSO item, int quantity)
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
    public Item GetItem(ItemType type)
    {
        foreach (InventorySlot slot in inventorySlotList)
        {
            if (slot.item.type == type)
            {
                return slot.item.prefab.GetComponent<Item>();
            }
        }
        return null;
    }
}
