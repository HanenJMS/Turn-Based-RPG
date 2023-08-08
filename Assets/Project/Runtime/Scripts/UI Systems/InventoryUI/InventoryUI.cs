using RPGSandBox.InteractableSystem;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public class InventoryUI : MonoBehaviour
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
            InteractableSelectionSystem.instance.OnInteractableSelected += OnselectedInteractable;
            InteractableSelectionSystem.instance.OnActivateInventoryUI += ActivateUI;
        }

        public void ActivateUI()
        {
            ClearUI();
            
            if (selectedInventory != null)
            {
                List<InventorySlot> inventory = selectedInventory.GetInventorySlots();
                foreach(InventorySlot inventorySlot in inventory)
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
        void ClearUI()
        {
            if (slots == null) return;
            foreach(ItemSlotUI slotUI in slots)
            {
                Destroy(slotUI.gameObject);
            }
            slots.Clear();
        }
        private void OnselectedInteractable(IAmInteractable interactable)
        {
            if (interactable.GetMyInventory() == null || interactable as IAmAUnit == selectedUnit)
            {
                ActivateUI();
                return;
            }
            if(interactable is IAmAUnit)
            {
                selectedUnit = interactable as IAmAUnit;
                selectedInventory = interactable.GetMyInventory();
            }
            
        }
    }
}

