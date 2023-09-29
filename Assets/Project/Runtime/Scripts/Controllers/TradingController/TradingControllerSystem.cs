using RPGSandBox.InterfaceSystem;
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
        IAmATrader playerTrader, targetedTrader;
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
        public void OpenItemWindow()
        {
            OnStartItemTradeWindow?.Invoke();
        }
    }
}

