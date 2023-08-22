using RPGSandBox.InterfaceSystem;
using RPGSandBox.MerchantSystem;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class MerchantUI : MonoBehaviour, IAmAGameUI
    {
        IAmAnInventory merchant1, merchant2;
        private void Start()
        {
            GameMerchantSystem.Instance.OnActivateTradeUI += ActivateUICustom;
        }
        void ActivateUICustom(IAmATrader merchant1, IAmATrader merchant2)
        {
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

