using RPGSandBox.GameUI;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using RPGSandBox.TradingSystem;
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
            playerTrader.Market().GetDemandList().Inventory().AddToInventory(inventorySlot);
        }
        internal void AddSellTrade(IAmAnInventorySlot inventorySlot)
        {
            OnSelectedUnit();
            playerTrader.Market().GetSupplyList().Inventory().AddToInventory(inventorySlot);
        }
        internal void BuyItem(IAmAnInventorySlot inventorySlot)
        {
            if (!GetTargetTrader().Market().GetSupplyList().Inventory().Contains(inventorySlot)) return;

            TradingInventorySlot(playerTrader.GetInventory(), GetTargetTrader().Market().GetSupplyList().Inventory(), inventorySlot);
        }

        internal void SellItem(IAmAnInventorySlot inventorySlot)
        {
            if (!playerTrader.GetInventory().Contains(inventorySlot)) return;
            TradingInventorySlot(GetTargetTrader().GetInventory(), playerTrader.GetInventory(), inventorySlot);
        }

        void TradingInventorySlot(IAmAnInventory AddToInventory, IAmAnInventory RemoveFromInventory, IAmAnInventorySlot tradingSlot)
        {
            AddToInventory.AddToInventory(tradingSlot);
            RemoveFromInventory.RemoveFromInventory(tradingSlot);
        }
    }
}

