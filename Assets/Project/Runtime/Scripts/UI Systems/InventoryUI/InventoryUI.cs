using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using RPGSandBox.UnitSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public class InventoryUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform inventoryBodyContainer;
        [SerializeField] RectTransform itemSlot;
        [SerializeField] GridLayoutGroup gridLayout;
        IAmAUnit selectedUnit;
        [SerializeField] IHaveAnInventory selectedInventory;
        [SerializeField] List<ItemSlotUI> slots = new List<ItemSlotUI>();
        [SerializeField] float gridScale = 50f;
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnselectedInteractable;
            InterfaceControllerSystem.instance.OnActivateInventoryUI += ActivateUI;
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
            ClearUI();

            if (selectedInventory != null)
            {
                List<InventorySlot> inventory = selectedInventory.GetInventorySlots();
                foreach (InventorySlot inventorySlot in inventory)
                {
                    RectTransform ui = Instantiate(itemSlot, inventoryBodyContainer);

                    ItemSlotUI slotUI = ui.GetComponent<ItemSlotUI>();
                    slotUI.SetItem(inventorySlot.item.ItemType(), inventorySlot.item.GetQuantity());
                    slotUI.GetComponent<LayoutElement>().minHeight = gridScale;
                    slotUI.GetComponent<LayoutElement>().minWidth = gridScale;
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
            selectedInventory = selectedUnit.GetMyInventory();
        }


    }
}

