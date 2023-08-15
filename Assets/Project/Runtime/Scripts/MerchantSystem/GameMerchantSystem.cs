using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;
namespace RPGSandBox.MerchantSystem
{
    public class GameMerchantSystem : MonoBehaviour
    {
        public static GameMerchantSystem Instance { get; private set; }
        IAmATrader merchant1, merchant2;
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
        public void StartTrade(IAmATrader merchant1, IAmATrader merchant2)
        {
            this.merchant1 = merchant1;
            this.merchant2 = merchant2;
            OnActivateTradeUI?.Invoke(merchant1, merchant2);
        }
    }
}

