using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] Image image;
    ItemSO item;

    public void SetItem(ItemSO item)
    {
        this.item = item;
        this.image.sprite = item.sprite;
    }
}
