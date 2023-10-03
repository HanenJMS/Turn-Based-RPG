using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class TradingSystemUI : MonoBehaviour, IAmAGameUI
    {
        IAmATrader playerTrader, targetTrader;
        [SerializeField] RectTransform SupplyTradeWindowTransform;
        [SerializeField] RectTransform DemandTradeWindowTransform;
        [SerializeField] RectTransform ItemTradeWindowTransform;
        private void Start()
        {
            TradingControllerSystem.Instance.OnActivateTradeUI += ActivateUICustom;
            TradingControllerSystem.Instance.OnStartItemTradeWindow += OpenItemWindow;
            ItemTradeWindowTransform.gameObject.SetActive(false);
        }
        void ActivateUICustom(IAmATrader playerTrader, IAmATrader targetTrader)
        {
            this.playerTrader = playerTrader;
            this.targetTrader = targetTrader;
            //SupplyTradeWindowTransform.GetComponent<MarketTypeUI>().SetMarketUI(targetTrader.Market().GetSupplyList());
            //DemandTradeWindowTransform.GetComponent<MarketTypeUI>().SetMarketUI(targetTrader.Market().GetDemandList());
            
            ActivateUI();
        }
        public void OpenItemWindow()
        {
            ItemTradeWindowTransform.gameObject.SetActive(true);
        }
        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
        }

        public void ClearUI()
        {

        }

        public void DeActivateUI()
        {
            this.gameObject.SetActive(false);
            ItemTradeWindowTransform.gameObject.SetActive(false);
        }

        public void UpdateUI()
        {
            throw new System.NotImplementedException();
        }
    }
}

