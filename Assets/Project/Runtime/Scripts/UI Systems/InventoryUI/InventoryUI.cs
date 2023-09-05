using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class InventoryUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform inventoryBodyContainer;
        [SerializeField] RectTransform itemSlot;
        IAmAUnit selectedUnit;
        [SerializeField] IAmAnInventory selectedInventory;
        [SerializeField] List<ItemSlotUI> slots = new List<ItemSlotUI>();
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnselectedInteractable;
            InterfaceControllerSystem.Instance.OnActivateInventoryUI += ActivateUI;
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
            ClearUI();

            if (selectedInventory != null)
            {
                List<InventorySlot> inventory = selectedInventory.GetInventoryList();
                foreach (InventorySlot inventorySlot in inventory)
                {
                    RectTransform ui = Instantiate(itemSlot, inventoryBodyContainer);

                    ItemSlotUI slotUI = ui.GetComponent<ItemSlotUI>();
                    slotUI.SetItem(inventorySlot.GetItemType(), inventorySlot.Quantity());
                    slots.Add(slotUI);
                }
            }
        }
        public void DeActivateUI()
        {
            ClearUI();
            this.gameObject.SetActive(false);
        }
        public void ClearUI()
        {
            if (slots == null) return;
            foreach (ItemSlotUI slotUI in slots)
            {
                Destroy(slotUI.gameObject);
            }
            slots.Clear();
        }
        private void OnselectedInteractable()
        {
            selectedUnit = UnitSelectionSystem.Instance.GetUnit();
            selectedInventory = selectedUnit.Inventory();
        }
    }
}

