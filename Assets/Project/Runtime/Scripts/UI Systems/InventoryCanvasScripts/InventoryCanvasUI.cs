using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
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
            InterfaceControllerSystem.Instance.OnUpdateInventoryUI += UpdateUI;
        }

        private void SelectedUnit()
        {
            inventory = UnitSelectionSystem.Instance.GetUnit().Inventory();
            UpdateUI();
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
            inventoryUI.GetComponent<InventoryUI>().ActivateUI(inventory);
            inventoryUI.GetComponent<InventoryUI>().ActivateUI();
        }
        public void UpdateUI()
        {
            inventoryUI.GetComponent<InventoryUI>().UpdateUI(inventory);
        }
    }


}

