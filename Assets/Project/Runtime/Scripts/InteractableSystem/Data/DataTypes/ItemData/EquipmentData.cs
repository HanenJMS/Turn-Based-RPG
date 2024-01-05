using UnityEngine;

namespace RPGSandBox.InteractableSystem
{
    [CreateAssetMenu(fileName = "EquipmentItem", menuName = "InventorySystem/Items/EquipmentItem")]
    public class EquipmentData : ItemData
    {
        public float attackBonus;
        public float DefenseBonus;

    }

}
