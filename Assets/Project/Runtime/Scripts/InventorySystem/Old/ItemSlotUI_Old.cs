using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI_Old : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    ItemType item;

    public void SetItem(ItemType item, int qty)
    {
        this.item = item;
        this.image.sprite = item.sprite;
        text.text = $"{qty}";
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
