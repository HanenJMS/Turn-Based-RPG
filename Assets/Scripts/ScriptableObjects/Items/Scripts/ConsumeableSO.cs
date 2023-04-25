using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumeable SO", menuName = "InventorySystem/Items/Consumeable")]
public class ConsumeableSO : ItemSO
{
    private void Awake()
    {
        type = ItemType.Consumeable;
    }
}
