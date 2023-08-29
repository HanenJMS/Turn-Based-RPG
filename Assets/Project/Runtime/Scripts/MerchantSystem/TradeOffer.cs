using RPGSandBox.GameInteractionStatesSystem;
using RPGSandBox.InventorySystem;

namespace RPGSandBox.MerchantSystem
{
    [System.Serializable]
    public class TradeOffer
    {
        public ItemType item;
        public int qty;
        public TradeOfferState tradeType;
    }
}

