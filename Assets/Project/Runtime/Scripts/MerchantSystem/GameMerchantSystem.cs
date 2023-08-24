using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;
namespace RPGSandBox.MerchantSystem
{
    public class GameMerchantSystem : MonoBehaviour
    {
        public static GameMerchantSystem Instance { get; private set; }
        IAmATrader merchantPlayerSelected, merchantPlayerSelectedTarget;
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
            merchantPlayerSelected = UnitSelectionSystem.Instance.GetUnit().Trader();
        }
        public void StartTrade(object target)
        {
            IAmAUnit unitTarget = target as IAmAUnit;
            merchantPlayerSelectedTarget = unitTarget.Trader();
            OnActivateTradeUI?.Invoke(merchantPlayerSelected, merchantPlayerSelectedTarget);
        }
    }
}

