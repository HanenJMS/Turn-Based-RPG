using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InventorySystem.Item
{
    public class Item : MonoBehaviour, IAmAnItem
    {
        public ItemType item;
        public int quantity;
        public int quality;
        public bool isOwned = false;

        public Item(ItemType item, int quantity, int quality)
        {
            this.item = item;
            this.quantity = quantity;
            this.quality = quality;
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

