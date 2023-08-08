using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmInteractable
    {
        Vector3 MyPosition();
        void Interact(IAmInteractable interact);
        IHaveAnInventory GetMyInventory();
        string InteractableName();
        string DescriptionHeader();
        string DescriptionContent();
    }
}

