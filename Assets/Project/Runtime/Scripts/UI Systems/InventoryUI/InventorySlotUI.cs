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
        ItemType item;
        public virtual void SetItemSlotUI(IAmAnInventorySlot inventorySlot)
        {
            SetItemType(inventorySlot);
            SetItemImage();
            SetCounterText(inventorySlot.Quantity().ToString());
        }

        private void SetItemType(IAmAnInventorySlot inventorySlot)
        {
            this.item = inventorySlot.GetItemType();
        }

        private void SetItemImage()
        {
            this.image.sprite = item.sprite;
        }

        public void SetCounterText(string CounterText)
        {
            countText.text = CounterText;
        }
    }
}

