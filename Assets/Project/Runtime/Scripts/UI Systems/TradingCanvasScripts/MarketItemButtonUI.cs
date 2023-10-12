using RPGSandBox.Controller;
namespace RPGSandBox.GameUI
{
    public class MarketItemButtonUI : InventorySlotButtonUI
    {
        public override void DoButtonLogic()
        {
            InterfaceControllerSystem.Instance.ActivateItemInteractionWindowUI(GetInventorySlot());
        }
    }
}
