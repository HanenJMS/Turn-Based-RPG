using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmInteractable
    {
        Vector3 GetWorldPosition();
        bool CanInteract(IAmInteractable interact);
        string InteractableName();
        string DescriptionHeader();
        string DescriptionContent();
    }
}

