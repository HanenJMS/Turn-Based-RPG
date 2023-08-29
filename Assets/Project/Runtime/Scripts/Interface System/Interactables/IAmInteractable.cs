using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmInteractable
    {
        Vector3 GetCurrentWorldPosition();
        bool CanInteract(IAmInteractable interact);
        string InteractableName();
        string DescriptionHeader();
        string DescriptionContent();
    }
}

