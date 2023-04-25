using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment SO", menuName = "InventorySystem/Items/Equipment")]

public class EquipmentSO : ItemSO
{
    public float attackBonus;
    public float DefenseBonus;

    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
