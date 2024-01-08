using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.InteractableSystem
{
    public abstract class InteractableWorldObject : MonoBehaviour, IAmInteractable
    {
        [SerializeField] InteractableData interactableDataType;
        public bool CanInteract(IAmInteractable interact)
        {
            return true;
        }

        public virtual InteractableData GetInteractableData()
        {
            return interactableDataType;
        }

        public Vector3 GetWorldPosition()
        {
            return this.transform.position;
        }
    }
}
