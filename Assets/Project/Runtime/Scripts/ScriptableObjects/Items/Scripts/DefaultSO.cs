using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default SO", menuName = "InventorySystem/Items/Default")]
public class DefaultSO : ItemSO
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
