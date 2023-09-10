using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    public class ItemWorld : MonoBehaviour, IAmAnItem
    {
        [SerializeField] ItemType itemType;
        [SerializeField] InventorySlot ItemWorldInventorySlot;
        [SerializeField] int startingCount = 1;
        private void Start()
        {
            ItemWorldInventorySlot = new(itemType, startingCount);
        }
        public ItemType ItemType()
        {
            return itemType;
        }
        public InventorySlot GetItemWorldInventorySlot()
        {
            return ItemWorldInventorySlot;
        }
        public Vector3 GetWorldPosition()
        {
            return this.transform.position;
        }

        public IAmAnItem PickUpItem()
        {

            IAmAnItem item = this;
            if (item == null) return null;
            if (GetItemWorldInventorySlot().Quantity() <= 0)
            {
                Destroy(this.gameObject);
            }
            return item;
        }
        public bool CanInteract(IAmInteractable interact)
        {
            return false;
        }
        public string DescriptionHeader()
        {
            return itemType.itemName;
        }
        public string DescriptionContent()
        {
            string description = itemType.description;
            return description;
        }

        public string InteractableName()
        {
            return itemType.itemName;
        }
    }
}

