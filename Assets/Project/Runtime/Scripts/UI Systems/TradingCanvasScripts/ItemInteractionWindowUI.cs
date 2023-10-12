using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

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
            BuyButton.onClick.AddListener(() => TradingControllerSystem.Instance.BuyItem(GetInteractionInventorySlot()));
            SellButton.onClick.AddListener(() => TradingControllerSystem.Instance.SellItem(GetInteractionInventorySlot()));
            TradeBuyButton.onClick.AddListener(() => TradingControllerSystem.Instance.AddBuyTrade(GetInteractionInventorySlot()));
            TradeSellButton.onClick.AddListener(() => TradingControllerSystem.Instance.AddSellTrade(GetInteractionInventorySlot()));
            DeActivateUI();
        }
        public IAmAnInventorySlot GetInteractionInventorySlot()
        {
            InventorySlot itemSlot = new(inventorySlot.GetInventorySlot().GetItemType(), (int)slider.value);
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
        }

        public void ClearUI()
        {

        }

        public void UpdateUI()
        {

        }
    }
}

