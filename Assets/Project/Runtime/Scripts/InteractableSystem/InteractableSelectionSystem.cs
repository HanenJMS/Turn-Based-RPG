using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;
namespace RPGSandBox.InteractableSystem
{
    public class InteractableSelectionSystem : PlayerControllerSystem
    {
        public static InteractableSelectionSystem instance;
        [SerializeField] IAmInteractable selected;
        public Action OnInteractableSelected;
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(this.gameObject);
            }
            instance = this;
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
            if(hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                selected = interactable;
                OnInteractableSelected?.Invoke();
            }
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
    }
}

