using RPGSandBox.InterfaceSystem;
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
            this.image.sprite = inventorySlot.GetItemType().GetInteractableSprite();
        }

        public void SetCounterText(string CounterText)
        {
            countText.text = CounterText;
        }
        public void SetNameText()
        {
            if (nameText == null) return;
            nameText.text = inventorySlot.GetItemType().name;;
        }
        public IAmAnInventorySlot GetInventorySlot()
        {
            return inventorySlot;
        }
    }
}

