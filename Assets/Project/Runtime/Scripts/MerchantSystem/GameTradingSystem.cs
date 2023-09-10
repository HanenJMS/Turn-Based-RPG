using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System;
using UnityEngine;
namespace RPGSandBox.TradingSystem
{
    public class GameTradingSystem : MonoBehaviour
    {
        public static GameTradingSystem Instance { get; private set; }
        IAmATrader playerTrader, targetedTrader;
        public Action<IAmATrader, IAmATrader> OnActivateTradeUI;
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            PlayerActionController.Instance.playerStartsTrade += StartTrade;
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }
        private void OnSelectedUnit()
        {
            playerTrader = UnitSelectionSystem.Instance.GetUnit().Trader();
        }
        public void StartTrade(object target)
        {
            if (target is not IAmATrader) return;
            targetedTrader = target as IAmATrader;
            OnActivateTradeUI?.Invoke(playerTrader, targetedTrader);
            
            playerTrader.Market().GetDemandList();
            playerTrader.Market().GetSupplyList();
        }
    }
}

