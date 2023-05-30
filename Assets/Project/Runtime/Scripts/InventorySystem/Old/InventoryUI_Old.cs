using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI_Old : MonoBehaviour
{
    Inventory_Old inventory;
    [SerializeField] Transform itemSlotUI;
    [SerializeField] Transform itemSlotButtonContainer;
    List<ItemSlotUI_Old> itemSlotList = new List<ItemSlotUI_Old>();
    //bool iSActive = false;
    private void Start()
    {
        //inventory = UnitActionSystem.Instance.GetSelectedUnit().GetInventory();
        CreateUIElements();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ToggleUIInventory();
        }
    }
    void CreateUIElements()
    {
        ClearInventorySlots();
        foreach (InventorySlot item in inventory.GetItemList())
        {
            Transform go = Instantiate(itemSlotUI, itemSlotButtonContainer);
            ItemSlotUI_Old itemSlotUIobject = go.GetComponent<ItemSlotUI_Old>();
            itemSlotUIobject.SetItem(item.item, item.quantity);
            itemSlotList.Add(itemSlotUIobject);
            itemSlotUIobject.Hide();
        }
    }
    void ToggleUIInventory()
    {
        UpdateVisuals();
    }
    void UpdateVisuals()
    {
        CreateUIElements();
        foreach(ItemSlotUI_Old itemUI in itemSlotList)
        {
            itemUI.Show();
        }
    }
    private void ClearInventorySlots()
    {
        foreach (Transform buttons in itemSlotButtonContainer)
        {
            Destroy(buttons.gameObject);
        }

        itemSlotList.Clear();
    }
}
