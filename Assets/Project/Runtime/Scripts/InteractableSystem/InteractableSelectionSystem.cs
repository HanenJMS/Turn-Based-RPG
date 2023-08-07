using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;

namespace RPGSandBox.InteractableSystem
{
    public class InteractableSelectionSystem : MouseInputController
    {
        public static InteractableSelectionSystem instance { get; private set; }
        [SerializeField] IAmInteractable selected;
        public Action<IAmInteractable> OnInteractableSelected;
        public Action OnActivateInteractableUI;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
        }
        public override void Update()
        {
            base.Update();
            HandleInputInterfaceKey();
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
            selected = null;
            if (hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                selected = interactable;
                OnInteractableSelected?.Invoke(selected);
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

        public void HandleInputInterfaceKey()
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                OnActivateInteractableUI?.Invoke();
            }
        }
    }
}

