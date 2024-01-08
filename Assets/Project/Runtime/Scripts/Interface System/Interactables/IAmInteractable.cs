using RPGSandBox.InteractableSystem;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmInteractable
    {
        Vector3 GetWorldPosition();
        bool CanInteract(IAmInteractable interact);
        InteractableData GetInteractableData();
    }
}

