using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] Transform itemSlotUI;
    [SerializeField] Transform itemSlotButtonContainer;
    List<ItemSlotUI> itemSlotList = new List<ItemSlotUI>();
    private void Start()
    {
        inventory = UnitActionSystem.Instance.GetSelectedUnit().GetInventory();
        CreateUIElements();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            CreateUIElements();
        }
    }
    void CreateUIElements()
    {
        itemSlotList.Clear();
        foreach(InventorySlot item in inventory.GetItemList())
        {
            Transform go = Instantiate(itemSlotUI, itemSlotButtonContainer);
            ItemSlotUI itemSlotUIobject = go.GetComponent<ItemSlotUI>();
            itemSlotUIobject.SetItem(item.item);
            itemSlotList.Add(itemSlotUIobject);
        }
    }
}
