using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using RPGSandBox.TradingSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class TradingControllerSystem : MonoBehaviour
    {
        public static TradingControllerSystem Instance { get; private set; }
        public Action OnStartItemTradeWindow;
        MarketType marketType;
        ItemType itemTrade;
        IAmATrader playerTrader, targetedTrader;
        IAmAnInventorySlot tradingSlot;
        public Action<IAmATrader, IAmATrader> OnActivateTradeUI;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            PlayerActionControllerSystem.Instance.playerStartsTrade += StartTrade;
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }
        public void StartTrade(object target)
        {
            if (target is not IAmAUnit) return;
            targetedTrader = (target as IAmAUnit).Trader();
            OnActivateTradeUI?.Invoke(playerTrader, targetedTrader);
        }
        private void OnSelectedUnit()
        {
            playerTrader = UnitSelectionSystem.Instance.GetUnit().Trader();
        }
        public void SetMarketType(MarketType market)
        {
            marketType = market;
        }
        public void SetTradeItem(ItemType itemType)
        {
            itemTrade = itemType;
        }
        public void SetTradingSlot(IAmAnInventorySlot tradingSlot)
        {
            this.tradingSlot = tradingSlot;
        }
        public IAmAnInventorySlot GetTradingSlot()
        {
            return this.tradingSlot;
        }
        public void OpenItemWindow()
        {
            OnActivateTradeUI?.Invoke(playerTrader, targetedTrader);
            OnStartItemTradeWindow?.Invoke();
        }
        internal void Trade(int quantity)
        {

        }

        internal void Buy(int quantity)
        {
            InventorySlot newSlot = new(tradingSlot.GetItemType(), quantity);
            playerTrader.Market().GetDemandList().Inventory().AddToInventory(newSlot);
        }

        internal void Sell(int quantity)
        {
            InventorySlot newSlot = new(tradingSlot.GetItemType(), quantity);
            playerTrader.Market().GetSupplyList().Inventory().AddToInventory(newSlot);
        }
    }
}

