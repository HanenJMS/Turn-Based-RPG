using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace RPGSandBox.GameUI
{
    public class MarketInventorySlotUI_Slider: InventorySlotUI
    {
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] UnityEngine.UI.Slider slider;
        string countTexture = "";
        private void OnEnable()
        {
            slider.value = 0;
            slider.maxValue = 356;
        }
        public override void SetItemSlotUI(IAmAnInventorySlot inventorySlot)
        {
            base.SetItemSlotUI(inventorySlot);
            itemName.text = inventorySlot.GetItemType().itemName;
        }
        private void LateUpdate()
        {
            SetCounterText($"{slider.value}/{slider.maxValue}");
        }
    }
}
