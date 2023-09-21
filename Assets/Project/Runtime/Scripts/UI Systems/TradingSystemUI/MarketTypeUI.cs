using RPGSandBox.TradingSystem;
using UnityEngine;
namespace RPGSandBox.GameUI
{
    public class MarketTypeUI : MonoBehaviour
    {
        [SerializeField] MarketInventoryUI inventoryUI;
        [SerializeField] MarketType marketType;
        private void Awake()
        {
            inventoryUI = GetComponentInChildren<MarketInventoryUI>();
        }
        public void SetMarketUI(MarketType market)
        {
            marketType = market;
            inventoryUI.SetMarket(marketType);
        }
    }
}

