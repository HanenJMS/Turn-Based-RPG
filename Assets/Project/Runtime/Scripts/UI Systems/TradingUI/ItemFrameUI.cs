using RPGSandBox.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class ItemFrameUI
        : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI countText;
        ItemType item;
        public void SetItem(ItemType item, int count = 0)
        {
            this.item = item;
            this.image.sprite = item.sprite;
            countText.text = $"{count}";
        }
    }
}
