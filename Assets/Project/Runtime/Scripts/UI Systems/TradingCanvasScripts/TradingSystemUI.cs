using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using System;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class TradingSystemUI : MonoBehaviour
    {
        [SerializeField] RectTransform SupplyTradeWindowTransform;
        [SerializeField] RectTransform DemandTradeWindowTransform;
        private void OnEnable()
        {
            TradingControllerSystem.Instance.OnUpdatedTradeMenu += ActivateUI;
        }
        private void OnDisable()
        {
            TradingControllerSystem.Instance.OnUpdatedTradeMenu -= ActivateUI;
        }
        private void Start()
        {
            TradingControllerSystem.Instance.OnStartTrade += ActivateUI;
            
        }

        private void ActivateUI()
        {
            if (!this.gameObject.activeSelf) return;
            SupplyTradeWindowTransform.GetComponent<InventoryUI>().ActivateUI(TradingControllerSystem.Instance.GetTargetTrader().Market().GetSupplyList().Inventory());
            SupplyTradeWindowTransform.GetComponent<InventoryUI>().ActivateUI();

            DemandTradeWindowTransform.GetComponent<InventoryUI>().ActivateUI(TradingControllerSystem.Instance.GetTargetTrader().Market().GetDemandList().Inventory());
            DemandTradeWindowTransform.GetComponent<InventoryUI>().ActivateUI();
        }
    }
}

