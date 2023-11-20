using RPGSandBox.Controller;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class TradingSystemUI : MonoBehaviour
    {
        [SerializeField] RectTransform SupplyTradeWindowTransform;
        [SerializeField] RectTransform DemandTradeWindowTransform;

        private void Start()
        {
            TradingControllerSystem.Instance.OnStartTrade += ActivateUI;
            TradingControllerSystem.Instance.OnUpdatedTradeMenu += ActivateUI;
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

