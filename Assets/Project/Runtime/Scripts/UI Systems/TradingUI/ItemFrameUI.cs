using RPGSandBox.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace RPGSandBox.GameUI
{
    public class ItemFrameUI: MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI countText;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] UnityEngine.UI.Slider slider;
        ItemType item;
        private void OnEnable()
        {
            slider.value = 0;
            slider.maxValue = 356;
        }
        public void SetItem(ItemType item, int count = 0)
        {
            this.item = item;
            this.image.sprite = item.sprite;
            this.itemName.text = item.itemName;
            slider.maxValue = count;
            countText.text = $"{slider.value}/{slider.maxValue}";
        }
        private void Update()
        {
            countText.text = $"{slider.value}/{slider.maxValue}";
        }
    }
}
