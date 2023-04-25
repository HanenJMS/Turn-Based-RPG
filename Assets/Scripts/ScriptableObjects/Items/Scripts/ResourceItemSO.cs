using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceItemSO SO", menuName = "InventorySystem/Items/ResourceItemSO")]
public class ResourceItemSO : ItemSO
{
    public void Awake()
    {
        type = ItemType.Copper;
    }
}
