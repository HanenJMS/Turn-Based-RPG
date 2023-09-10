using RPGSandBox.InterfaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] ItemSlotUI itemSlotUI;

        public virtual void DisplayInventoryItems(IAmAnInventory inventory)
        {
            foreach(IAmAnInventorySlot inventorySlot in inventory.GetInventoryList())
            {
                itemSlotUI = new();
                itemSlotUI.SetItemSlotUI(inventorySlot);
                Instantiate(itemSlotUI, this.transform);
            }
        }
    }
}

