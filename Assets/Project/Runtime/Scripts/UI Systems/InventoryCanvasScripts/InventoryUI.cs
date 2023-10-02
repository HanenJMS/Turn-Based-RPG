using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;

namespace RPGSandBox.GameUI
{
    public class InventoryUI : InventoryUI_Base
    {
        private void Start()
        {
            InterfaceControllerSystem.Instance.OnActivateInventoryUI += ActivateUI;
        }
        IAmAnInventory currentinventory;
        public override void ActivateUI()
        {
            base.ActivateUI();
            if (!TryGetInventory()) return;
            ActivateUI(currentinventory);
        }

        private bool TryGetInventory()
        {
            if (UnitSelectionSystem.Instance.GetUnit() == null) return false;
            if (UnitSelectionSystem.Instance.GetUnit().Inventory() == null) return false;
            currentinventory = UnitSelectionSystem.Instance.GetUnit().Inventory();
            return true;
        }

        public override void ExtendInventorySlotUI(InventorySlotUI newItemSlotUI)
        {

        }
    }
}
