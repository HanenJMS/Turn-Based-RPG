using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InventorySystem.Item
{
    public class Item : MonoBehaviour, IAmAnItem
    {
        [SerializeField] ItemType itemType;
        [SerializeField] IAmAUnit owner;
        [SerializeField] int quantity;
        [SerializeField] int quality;

        public Item(ItemType itemType, int quantity, int quality, IAmAUnit owner = null)
        {
            this.itemType = itemType;
            this.quantity = quantity;
            this.quality = quality;
            this.owner = owner;
        }
        public ItemType ItemType()
        {
            return itemType;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public int GetQuality()
        {
            return quality;
        }
        public void AddingQuantity(int quantity)
        {
            this.quantity += quantity;
        }
        public void RemovingQuantity(int quantity)
        {
            this.quantity -= quantity;
        }
        public bool HasAnOwner()
        {
            return owner != null;
        }
        public bool OwnedBy(IAmAUnit owner)
        {
            return this.owner == owner;
        }
        public Vector3 MyPosition()
        {
            return this.transform.position;
        }
        public void SetOwner(IAmAUnit owner)
        {
            if(!OwnedBy(owner))
                this.owner = owner;
        }
        public IAmAnItem PickUpItem()
        {
            
            IAmAnItem item = this;
            if (item == null) return null;
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            return item;
        }
        public void Interact(IAmInteractable interact)
        {

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

