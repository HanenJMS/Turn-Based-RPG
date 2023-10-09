using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI countText;
        [SerializeField] TextMeshProUGUI nameText;
        IAmAnInventorySlot inventorySlot;
        public virtual void SetItemSlotUI(IAmAnInventorySlot inventorySlot)
        {
            this.inventorySlot = inventorySlot;
            InitializeUI();
        }

        private void InitializeUI()
        {
            SetItemImage();
            SetCounterText(this.inventorySlot.Quantity().ToString());
            SetNameText();
        }

        private void SetItemImage()
        {
            this.image.sprite = inventorySlot.GetItemType().sprite;
        }

        public void SetCounterText(string CounterText)
        {
            countText.text = CounterText;
        }
        public void SetNameText()
        {
            if (nameText == null) return;
            nameText.text = inventorySlot.GetItemType().itemName;
        }
        public IAmAnInventorySlot GetInventorySlot()
        {
            return inventorySlot;
        }
    }
}

