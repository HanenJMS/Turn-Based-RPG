using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class InventoryCanvasUI : MonoBehaviour
    {
        [SerializeField] RectTransform inventoryUI;
        IAmAnInventory inventory;
        private void Start()
        {
            InterfaceControllerSystem.Instance.OnActivateInventoryUI += ActivateUI;
            UnitSelectionSystem.Instance.OnSelectedUnit += SelectedUnit;
        }

        private void SelectedUnit()
        {
            inventory = UnitSelectionSystem.Instance.GetUnit().Inventory();
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
            inventoryUI.GetComponent<InventoryUI>().ActivateUI(inventory);
            inventoryUI.GetComponent<InventoryUI>().ActivateUI();
        }
    }


}

