using PlasticGui;
using RPGSandBox.Controller;
using RPGSandBox.GameUI;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
