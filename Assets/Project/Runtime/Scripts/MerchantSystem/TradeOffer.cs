using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.MerchantSystem
{
    public class TradeOffer : MonoBehaviour, IAmATradeOffer
    {
        Dictionary<IAmAnItem, int> tradeOffers = new Dictionary<IAmAnItem, int>();
        public TradeOffer(Dictionary<IAmAnItem, int> tradeOffers = null)
        {
            if(tradeOffers != null)
            {
                this.tradeOffers = tradeOffers;
            }
        }
    }
}

