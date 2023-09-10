using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public class ItemButtonUI : ItemSlotUI
    {
        [SerializeField] Button itemButton;

        private void Awake()
        {
            itemButton = GetComponent<Button>();
        }
        private void OnEnable()
        {
            GameTradingSystem.Instance.OnActivateTradeUI += something;
        }

        private void something(IAmATrader trader1, IAmATrader trader2)
        {
            throw new NotImplementedException();
        }
    }
}

