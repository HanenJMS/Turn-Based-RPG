using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public abstract class InventoryUI_Base : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform inventorySlotUI;
        [SerializeField] List<InventorySlotUI> inventorySlots;



        public virtual void DisplayInventoryItems(IAmAnInventory inventory)
        {
            ClearUI();
            foreach (IAmAnInventorySlot inventorySlot in inventory.GetInventoryList())
            {
                RectTransform newItemSlotTransform = Instantiate(inventorySlotUI, this.transform);
                InventorySlotUI newItemSlotUI = newItemSlotTransform.GetComponent<InventorySlotUI>();
                newItemSlotUI.SetItemSlotUI(inventorySlot);
                ExtendInventorySlotUI(newItemSlotUI);
            }
        }
        public void ActivateUI(IAmAnInventory inventory)
        {
            DisplayInventoryItems(inventory);
        }
        public void ActivateUI()
        {
            
        }

        public void ClearUI()
        {
            inventorySlots.Clear();
        }

        public void DeActivateUI()
        {
            throw new System.NotImplementedException();
        }
        public abstract void ExtendInventorySlotUI(InventorySlotUI newItemSlotUI);
    }
}

