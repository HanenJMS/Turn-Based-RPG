using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InventorySystem.Item
{
    public class Item : MonoBehaviour, IAmAnItem
    {
        [SerializeField] ItemType itemType;
        [SerializeField] int quantity;
        [SerializeField] int quality;
        [SerializeField] bool isOwned = false;

        public Item(ItemType itemType, int quantity, int quality)
        {
            this.itemType = itemType;
            this.quantity = quantity;
            this.quality = quality;
        }
        public ItemType ItemType()
        {
            return itemType;
        }

        public int QuantityIs()
        {
            return quantity;
        }

        public int ItemQualityIs()
        {
            return quality;
        }
        public void AddingQuantity(int quantity)
        {
            this.quantity += quantity;
        }
        public bool ItemHasAnOwner()
        {
            return isOwned;
        }

        public Vector3 MyPosition()
        {
            return this.transform.position;
        }

        public IAmAnItem PickUpItem()
        {
            if (!ItemHasAnOwner()) isOwned = true;
            IAmAnItem item = this;
            this.gameObject.SetActive(false);
            return item;
        }
        public void Interact(IAmInteractable interact)
        {

        }


    }
}

