using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public abstract class InventoryUI_Base : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform inventorySlotUI;
        [SerializeField] RectTransform contentUIrectTransform;
        [SerializeField] List<InventorySlotUI> inventorySlots;



        public virtual void DisplayInventoryItems(IAmAnInventory inventory)
        {
            ClearUI();
            foreach (IAmAnInventorySlot inventorySlot in inventory.GetInventoryList())
            {
                RectTransform newItemSlotTransform = Instantiate(inventorySlotUI, this.contentUIrectTransform);
                InventorySlotUI newItemSlotUI = newItemSlotTransform.GetComponent<InventorySlotUI>();
                newItemSlotUI.SetItemSlotUI(inventorySlot);
                inventorySlots.Add(newItemSlotUI);
                ExtendInventorySlotUI(newItemSlotUI);
            }
        }
        public void ActivateUI(IAmAnInventory inventory)
        {
            DisplayInventoryItems(inventory);
        }
        public virtual void ActivateUI()
        {
            this.gameObject.SetActive(true);
        }

        public void ClearUI()
        {
            foreach(InventorySlotUI uiSlot in inventorySlots)
            {
                Destroy(uiSlot.gameObject);
            }
            inventorySlots.Clear();
        }

        public void DeActivateUI()
        {
            this.gameObject.SetActive(false);
        }
        public abstract void ExtendInventorySlotUI(InventorySlotUI newItemSlotUI);
    }
}

