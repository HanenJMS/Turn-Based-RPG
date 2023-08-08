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
        public Action OnActivateInventoryUI;
        public Action OnClearUI;
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
            HandleInterface();
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
            OnClearUI?.Invoke();
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

        public void HandleInterface()
        {
            HandleInterfaceToggleKey();
            HandleInterfaceInventoryKey();
        }

        private void HandleInterfaceInventoryKey()
        {
            if(Input.GetKey(KeyCode.B))
            {
                OnClearUI?.Invoke();
                OnActivateInventoryUI?.Invoke();
            }
        }

        private void HandleInterfaceToggleKey()
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                OnClearUI?.Invoke();
                OnActivateInteractableUI?.Invoke();
            }
        }
    }
}

