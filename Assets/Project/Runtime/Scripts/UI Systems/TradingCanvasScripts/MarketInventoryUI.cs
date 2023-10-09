using RPGSandBox.TradingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class MarketInventoryUI : InventoryUI
    {
        MarketType market;

        //public override void ExtendInventorySlotUI(InventorySlotUI newItemSlotUI)
        //{
        //    if (newItemSlotUI is not MarketItemButtonUI) return;
        //    MarketItemButtonUI marketItem = newItemSlotUI as MarketItemButtonUI;
        //    marketItem.SetMarketType(market);
        //}
        public void SetMarket(MarketType market)
        {
            this.market = market;
        }
    }
}

