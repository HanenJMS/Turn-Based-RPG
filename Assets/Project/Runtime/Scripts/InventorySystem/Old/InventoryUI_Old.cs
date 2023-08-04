using System.Collections.Generic;
using UnityEngine;

public class InventoryUI_Old : MonoBehaviour
{
    //Inventory_Old inventory;
    //[SerializeField] Transform itemSlotUI;
    //[SerializeField] Transform itemSlotButtonContainer;
    //List<ItemSlotUI> itemSlotList = new List<ItemSlotUI>();
    ////bool iSActive = false;
    //private void Start()
    //{
    //    //inventory = UnitActionSystem.Instance.GetSelectedUnit().GetInventory();
    //    CreateUIElements();
    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        ToggleUIInventory();
    //    }
    //}
    //void CreateUIElements()
    //{
    //    ClearInventorySlots();
    //    foreach (InventorySlot_Old item in inventory.GetItemList())
    //    {
    //        Transform go = Instantiate(itemSlotUI, itemSlotButtonContainer);
    //        ItemSlotUI itemSlotUIobject = go.GetComponent<ItemSlotUI>();
    //        itemSlotUIobject.SetItem(item.item, item.quantity);
    //        itemSlotList.Add(itemSlotUIobject);
    //        itemSlotUIobject.Hide();
    //    }
    //}
    //void ToggleUIInventory()
    //{
    //    UpdateVisuals();
    //}
    //void UpdateVisuals()
    //{
    //    CreateUIElements();
    //    foreach (ItemSlotUI itemUI in itemSlotList)
    //    {
    //        itemUI.Show();
    //    }
    //}
    //private void ClearInventorySlots()
    //{
    //    foreach (Transform buttons in itemSlotButtonContainer)
    //    {
    //        Destroy(buttons.gameObject);
    //    }

    //    itemSlotList.Clear();
    //}
}
