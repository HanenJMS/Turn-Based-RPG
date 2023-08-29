using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InventorySystem
{
    public class Item : MonoBehaviour, IAmAnItem
    {
        [SerializeField] ItemType itemType;
        [SerializeField] InventorySlot ItemWorldInventorySlot;
        public Item(ItemType itemType)
        {
            this.itemType = itemType;
        }
        public ItemType ItemType()
        {
            return itemType;
        }
        public InventorySlot GetItemWorldInventorySlot()
        {
            return ItemWorldInventorySlot;
        }
        public Vector3 GetCurrentWorldPosition()
        {
            return this.transform.position;
        }

        public IAmAnItem PickUpItem()
        {

            IAmAnItem item = this;
            if (item == null) return null;
            Destroy(this.gameObject);
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

        public Item GetItem()
        {
            return this;
        }

    }
}

