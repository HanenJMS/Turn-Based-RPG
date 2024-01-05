using RPGSandBox.InteractableSystem;
using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InventorySystem
{
    public class ItemWorld : InteractableWorldObject, IAmAnItem
    {
        [SerializeField] ItemData itemType;
        [SerializeField] InventorySlot ItemWorldInventorySlot;
        [SerializeField] int startingCount = 1;
        private void Start()
        {
            ItemWorldInventorySlot = new(itemType, startingCount);
        }
        public ItemData ItemType()
        {
            return itemType;
        }
        public InventorySlot GetItemWorldInventorySlot()
        {
            return ItemWorldInventorySlot;
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
            return itemType.name;;
        }
        public string DescriptionContent()
        {
            string description = itemType.GetInteractableDescription();
            return description;
        }

        public string InteractableName()
        {
            return itemType.name;;
        }
    }
}

