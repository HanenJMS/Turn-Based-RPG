using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;
namespace RPGSandBox.Controller
{
    public class InteractableControllerSystem : MouseInputController
    {
        IAmInteractable interactable;
        public static InteractableControllerSystem Instance { get; private set; }
        public Action OnInteractableSelcted;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        public override void HandleLeftMouseDownEnd()
        {
            
        }

        public override void HandleLeftMouseDownMid()
        {
            
        }

        public override void HandleLeftMouseDownStart()
        {
            RaycastHit hit = MouseWorld.GetMouseRayCastHit();
            if (hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                SetSelected(interactable);
                OnInteractableSelcted?.Invoke();
            }
        }

        private void SetSelected(IAmInteractable interactable)
        {
            this.interactable = interactable;
        }

        public override void HandleRightMouseDownEnd()
        {
            
        }

        public override void HandleRightMouseDownMid()
        {
            
        }

        public override void HandleRightMouseDownStart()
        {
            
        }

        public IAmInteractable GetSelected()
        {
            if (interactable == null) return null;
            return interactable;
        }
    }
}

