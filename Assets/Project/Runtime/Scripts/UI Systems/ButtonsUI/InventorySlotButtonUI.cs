using RPGSandBox.InterfaceSystem;
using RPGSandBox.TradingSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public abstract class InventorySlotButtonUI : InventorySlotUI
    {
        [SerializeField] Button itemButton;

        private void Awake()
        {
            itemButton = GetComponent<Button>();
        }
        private void Start()
        {
            itemButton.onClick.AddListener(() =>
            {
                DoButtonLogic();
            });
        }
        public abstract void DoButtonLogic();
    }
}

