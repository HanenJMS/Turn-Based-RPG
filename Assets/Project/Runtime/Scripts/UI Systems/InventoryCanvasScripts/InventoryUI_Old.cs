using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;

namespace RPGSandBox.GameUI
{
    public class InventoryUI_Old : InventoryUI
    {

        IAmAnInventory currentinventory;


        private bool TryGetInventory()
        {
            if (UnitSelectionSystem.Instance.GetUnit() == null) return false;
            if (UnitSelectionSystem.Instance.GetUnit().Inventory() == null) return false;
            currentinventory = UnitSelectionSystem.Instance.GetUnit().Inventory();
            return true;
        }
    }
}
