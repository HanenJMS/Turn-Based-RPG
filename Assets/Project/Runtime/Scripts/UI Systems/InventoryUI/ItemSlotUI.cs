using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class ItemSlotUI : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI countText;
        ItemType item;
        public virtual void SetItemSlotUI(IAmAnInventorySlot inventorySlot)
        {
            this.item = inventorySlot.GetItemType();
            this.image.sprite = item.sprite;
            countText.text = $"{inventorySlot.Quantity()}";
        }
    }
}

