using RPGSandBox.Controller;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class MarketItemButtonUI : InventorySlotButtonUI
    {
        public enum MarketingType
        {
            Supply, Demand
        }

        [SerializeField] MarketingType marketType;
        public override void DoButtonLogic()
        {
            InterfaceControllerSystem.Instance.ActivateItemInteractionWindowUI(GetInventorySlot());
            InterfaceControllerSystem.Instance.ActivateTradeButtons(marketType);
        }
    }
}
