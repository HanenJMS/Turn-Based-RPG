using RPGSandBox.InterfaceSystem;
using RPGSandBox.MerchantSystem;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class TradingUI : MonoBehaviour, IAmAGameUI
    {
        IAmAnInventory playerMerchant, playerMerchantTarget;
        private void Start()
        {
            GameMerchantSystem.Instance.OnActivateTradeUI += ActivateUICustom;
        }
        void ActivateUICustom(IAmATrader playerMerchant, IAmATrader playerMerchantTarget)
        {
            this.playerMerchant = playerMerchant.Inventory();
            this.playerMerchantTarget = playerMerchantTarget.Inventory();
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

