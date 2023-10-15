using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class TradingControllerSystem : MonoBehaviour
    {
        public static TradingControllerSystem Instance { get; private set; }
        public Action OnStartTrade;
        public Action OnUpdatedTradeMenu;
        IAmATrader playerTrader, targetedTrader;
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
            OnStartTrade?.Invoke();
        }
        private void OnSelectedUnit()
        {
            playerTrader = UnitSelectionSystem.Instance.GetUnit().Trader();
        }

        public IAmATrader GetTargetTrader()
        {
            if (targetedTrader != null) return targetedTrader;
            OnSelectedUnit();
            return playerTrader;
        }
        internal void AddBuyTrade(IAmAnInventorySlot inventorySlot)
        {
            OnSelectedUnit();
            TradingInventorySlot(playerTrader.Market().GetDemandList().Inventory(), null, inventorySlot);
            OnUpdatedTradeMenu?.Invoke();
        }
        internal void AddSellTrade(IAmAnInventorySlot inventorySlot)
        {
            OnSelectedUnit();
            TradingInventorySlot(playerTrader.Market().GetSupplyList().Inventory(), playerTrader.GetInventory(), inventorySlot);
            OnUpdatedTradeMenu?.Invoke();
        }
        internal void BuyItem(IAmAnInventorySlot inventorySlot)
        {
            if (!GetTargetTrader().Market().GetSupplyList().Inventory().Contains(inventorySlot)) return;
            TradingInventorySlot(playerTrader.GetInventory(), GetTargetTrader().Market().GetSupplyList().Inventory(), inventorySlot);
            OnUpdatedTradeMenu?.Invoke();
        }

        internal void SellItem(IAmAnInventorySlot inventorySlot)
        {
            if (!playerTrader.GetInventory().Contains(inventorySlot)) return;
            TradingInventorySlot(GetTargetTrader().GetInventory(), playerTrader.GetInventory(), inventorySlot);
            OnUpdatedTradeMenu?.Invoke();
        }

        void TradingInventorySlot(IAmAnInventory AddToInventory, IAmAnInventory RemoveFromInventory, IAmAnInventorySlot tradingSlot)
        {
            if (AddToInventory == null) return;
            if (!AddToInventory.AddToInventoryQuantity(tradingSlot)) return;
            if (RemoveFromInventory == null) return;
            if (!RemoveFromInventory.RemoveFromInventoryQuantity(tradingSlot)) return;
        }
    }
}

