using RPGSandBox.Controller;
using RPGSandBox.TradingSystem;
namespace RPGSandBox.GameUI
{
    public class MarketItemButtonUI : InventorySlotButtonUI
    {
        MarketType marketType;
        public override void DoButtonLogic()
        {
            //TradingControllerSystem.Instance.SetMarketType(marketType);
            TradingControllerSystem.Instance.OpenItemWindow();
        }
        public void SetMarketType(MarketType MarketType)
        {
            this.marketType = MarketType;
        }
    }
}
