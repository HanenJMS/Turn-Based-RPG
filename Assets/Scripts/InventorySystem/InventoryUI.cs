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
            UpdateVisuals();
        }
    }
    void CreateUIElements()
    {
        ClearInventorySlots();
        foreach (InventorySlot item in inventory.GetItemList())
        {
            Transform go = Instantiate(itemSlotUI, itemSlotButtonContainer);
            ItemSlotUI itemSlotUIobject = go.GetComponent<ItemSlotUI>();
            itemSlotUIobject.SetItem(item.item, item.quantity);
            itemSlotList.Add(itemSlotUIobject);
            itemSlotUIobject.Hide();
        }
    }
    void UpdateVisuals()
    {
        CreateUIElements();
        foreach(ItemSlotUI itemUI in itemSlotList)
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
