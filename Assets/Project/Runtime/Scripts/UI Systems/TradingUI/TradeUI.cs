using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class TradeUI : MonoBehaviour, IAmAGameUI
    {
        IAmATrader playerTrader, targetTrader;
        [SerializeField]GameObject SupplyContextUI;
        [SerializeField]GameObject DemandContextUI;
        private void Start()
        {
            GameTradingSystem.Instance.OnActivateTradeUI += ActivateUICustom;
        }
        void ActivateUICustom(IAmATrader playerTrader, IAmATrader targetTrader)
        {
            this.playerTrader = playerTrader;
            this.targetTrader = targetTrader;
            ActivateUI();
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
        }

    }
}

