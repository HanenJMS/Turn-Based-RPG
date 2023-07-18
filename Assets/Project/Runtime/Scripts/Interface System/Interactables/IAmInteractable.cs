using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmInteractable
    {
        Vector3 MyPosition();
        void Interact(IAmInteractable interact);
        string DescriptionHeader();
        string DescriptionContent();
    }
}

