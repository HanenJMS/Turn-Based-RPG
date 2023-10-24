using Codice.Client.BaseCommands;
using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System;
using UnityEngine;
using UnityEngine.UI;
using static RPGSandBox.GameUI.MarketItemButtonUI;

namespace RPGSandBox.GameUI
{
    public class ItemInteractionWindowUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] Slider slider;
        InventorySlotUI inventorySlot;
        [SerializeField] Button BuyButton;
        [SerializeField] Button SellButton;
        [SerializeField] Button TradeBuyButton;
        [SerializeField] Button TradeSellButton;
        int count = 0;
        private void Awake()
        {
            inventorySlot = GetComponentInChildren<InventorySlotUI>();
            slider = GetComponentInChildren<Slider>();
        }
        private void Start()
        {
            InterfaceControllerSystem.Instance.OnActivateItemInteractionWindowUI += Activate;
            InterfaceControllerSystem.Instance.OnActivateTradeButtonsUI += ActivateTradeButtons;
            InterfaceControllerSystem.Instance.OnActivateMerchantButtonsUI += ActivateMerchantButtons;
            InterfaceControllerSystem.Instance.OnActivateMarketActionButtons += ActivateMarketActionButtons;
            BuyButton.onClick.AddListener(() => TradingControllerSystem.Instance.BuyItem(GetInteractionInventorySlot()));
            SellButton.onClick.AddListener(() => TradingControllerSystem.Instance.SellItem(GetInteractionInventorySlot()));
            TradeBuyButton.onClick.AddListener(() => TradingControllerSystem.Instance.AddBuyTrade(GetInteractionInventorySlot()));
            TradeSellButton.onClick.AddListener(() => TradingControllerSystem.Instance.AddSellTrade(GetInteractionInventorySlot()));
            DeActivateUI();
        }

        private void ActivateMarketActionButtons(MarketingType type)
        {
            ClearUI();
            if (type.Equals(MarketingType.Demand))
            {
                ActivateSellButton();
            }
            if(type.Equals(MarketingType.Supply))
            {
                ActivateBuyButton();
            }
        }

        public IAmAnInventorySlot GetInteractionInventorySlot()
        {
            InventorySlot itemSlot = new(inventorySlot.GetInventorySlot().GetItemType(), (int)slider.value);
            DeActivateUI();
            return itemSlot;
        }
        public void Activate(IAmAnInventorySlot inventorySlot)
        {
            this.inventorySlot.SetItemSlotUI(inventorySlot);
            slider.value = 0;
            count = inventorySlot.Quantity();
            slider.maxValue = inventorySlot.Quantity();
            ActivateUI();
        }

        public void Update()
        {
            inventorySlot.SetCounterText($"{slider.value}/{count}");
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);

        }

        public void DeActivateUI()
        {
            this.gameObject.SetActive(false);
            ClearUI();
        }
        public void ActivateMerchantButtons()
        {
            ClearUI();
            ActivateTradeBuyButton();
            ActivateTradeSellButton();
        }

        private void ActivateTradeSellButton()
        {
            TradeSellButton.gameObject.SetActive(true);
        }

        private void ActivateTradeBuyButton()
        {
            TradeBuyButton.gameObject.SetActive(true);
        }

        public void ActivateTradeButtons()
        {
            ClearUI();
            ActivateBuyButton();
            ActivateSellButton();
        }

        private void ActivateSellButton()
        {
            SellButton.gameObject.SetActive(true);
        }

        private void ActivateBuyButton()
        {
            BuyButton.gameObject.SetActive(true);
        }

        public void ClearUI()
        {
            BuyButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(false);
            TradeBuyButton.gameObject.SetActive(false);
            TradeSellButton.gameObject.SetActive(false);
        }

        public void UpdateUI()
        {

        }
    }
}

