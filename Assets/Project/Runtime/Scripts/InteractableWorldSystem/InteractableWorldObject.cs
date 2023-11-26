using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InteractableWorldSystem
{
    public class InteractableWorldObject : MonoBehaviour, IAmInteractable
    {
        public bool CanInteract(IAmInteractable interact)
        {
            throw new System.NotImplementedException();
        }

        public InteractableObjectData GetInteractableData()
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetWorldPosition()
        {
            throw new System.NotImplementedException();
        }
    }
}
