using UnityEngine;

public class Item_Old : MonoBehaviour
{
    public ItemType itemType;
    public ItemSO item;
    public int quantity;
    public int quality;

    public Item_Old(ItemType itemType, ItemSO item, int quantity, int quality)
    {
        this.itemType = itemType;
        this.item = item;
        this.quantity = quantity;
        this.quality = quality;
    }

    public void PickUpItem()
    {
        gameObject.SetActive(false);
    }
}
