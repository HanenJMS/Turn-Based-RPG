using RPGSandBox.InteractableSystem;
using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.GameUtilities.GridBuildingSystems
{
    public class Building : InteractableWorldObject, IAmInteractable
    {
        [SerializeField] string descriptionHeader;
        [TextArea(5,20)]
        [SerializeField] string descriptionContent;
        public bool CanInteract(IAmInteractable interact)
        {
            return true;
        }

        public string DescriptionContent()
        {
            return descriptionContent;
        }

        public string DescriptionHeader()
        {
            return descriptionHeader;
        }

        public Vector3 GetWorldPosition()
        {
            return this.transform.position;
        }

        public string InteractableName()
        {
            return descriptionHeader;
        }
    }
}

