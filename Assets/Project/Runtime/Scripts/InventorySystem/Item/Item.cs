using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InventorySystem.Item
{
    public class Item : MonoBehaviour, IAmAnItem
    {
        public IAmAnItem PickUpItem()
        {
            return this;
        }
    }
}

