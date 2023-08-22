using RPGSandBox.InterfaceSystem;
using RPGSandBox.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGSandBox.Controller
{
    public class PlayerActionController : MouseInputController
    {
        public static PlayerActionController instance { get; private set; }
        List<IAmAnAction> executableActions;
        public Action<object> OnMouseRightClick;
        public Action OnMouseLeftClick;
        public Action OnButtonClick;
        IAmAUnit currentUnit;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
        }
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }
        //MODIFY MODIFY MODIFY MODIFY MODIFY!!!!!!! Player Controller enters here. You can have it launch the UI and let the UI Execute the command.
        public void ExecuteAction(IAmAnAction action, object target)
        {
            action.Execute(target);
            OnButtonClick?.Invoke();
            currentUnit.Execute(action);
        }
        public List<IAmAnAction> ExecutableActions()
        {
            return executableActions;
        }
        public void OnSelectedUnit()
        {
            currentUnit = UnitSelectionSystem.Instance.GetUnit();
            executableActions = currentUnit.ActionList();
        }

        public override void HandleLeftMouseDownStart()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnMouseLeftClick?.Invoke();
            }
        }

        public override void HandleLeftMouseDownMid()
        {

        }

        public override void HandleLeftMouseDownEnd()
        {
        }

        public override void HandleRightMouseDownStart()
        {
            UpdateActionButtonUI();
        }



        public override void HandleRightMouseDownMid()
        {
            UpdateActionButtonUI();
        }

        public override void HandleRightMouseDownEnd()
        {
        }
        private void UpdateActionButtonUI()
        {
            RaycastHit hit = MouseWorld.GetMouseRayCastHit();
            if (hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                OnMouseRightClick?.Invoke(interactable);
                return;
            }
            OnMouseRightClick?.Invoke(MouseWorld.GetMousePosition());
        }
    }
}

