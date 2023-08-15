using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.UnitSystem
{
    public class UnitTrader : MonoBehaviour, IAmATrader
    {
        IHaveAnInventory inventory;
        public string DescriptionContent()
        {
            return "";
        }

        public string DescriptionHeader()
        {
            return "";
        }

        public IHaveAnInventory GetMyInventory()
        {
            return null;
        }

        public void Interact(IAmInteractable interact)
        {
            
        }

        public string InteractableName()
        {
            return "";
        }

        public Vector3 MyPosition()
        {
            return this.transform.position;
        }


    }
}

