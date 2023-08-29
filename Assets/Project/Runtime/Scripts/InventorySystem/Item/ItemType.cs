using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    public abstract class ItemType : ScriptableObject
    {
        public GameObject prefab;
        public Sprite sprite;
        public string itemName;
        [TextArea(15, 20)]
        public string description;
        public int qualityValue;
    }

}
