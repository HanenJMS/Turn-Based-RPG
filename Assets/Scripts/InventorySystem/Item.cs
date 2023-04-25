using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public ItemSO item;
    public int quantity;
    public int quality;

    public Item(ItemType itemType, ItemSO item, int quantity, int quality)
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
