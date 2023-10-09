using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class InventoryUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform inventorySlotButtonObject;
        [SerializeField] RectTransform contentUIrectTransform;
        [SerializeField] List<InventorySlotUI> inventorySlots;



        public void DisplayInventoryItems(IAmAnInventory inventory)
        {
            ClearUI();
            foreach (IAmAnInventorySlot inventorySlot in inventory.GetInventoryList())
            {
                RectTransform newItemSlotTransform = Instantiate(inventorySlotButtonObject, this.contentUIrectTransform);
                InventorySlotUI newItemSlotUI = newItemSlotTransform.GetComponent<InventorySlotUI>();
                newItemSlotUI.SetItemSlotUI(inventorySlot);
                inventorySlots.Add(newItemSlotUI);
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
            foreach (InventorySlotUI uiSlot in inventorySlots)
            {
                Destroy(uiSlot.gameObject);
            }
            inventorySlots.Clear();
        }

        public void DeActivateUI()
        {
            this.gameObject.SetActive(false);
        }

        public void UpdateUI()
        {
            throw new System.NotImplementedException();
        }
    }
}

