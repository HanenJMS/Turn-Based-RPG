using RPGSandBox.Controller;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class InventoryItemButtonUI : InventorySlotButtonUI
    {
        public override void DoButtonLogic()
        {
            InterfaceControllerSystem.Instance.ActivateItemInteractionWindowUI(GetInventorySlot());
        }
    }
}
