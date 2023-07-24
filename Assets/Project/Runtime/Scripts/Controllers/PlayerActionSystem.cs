using RPGSandBox.InterfaceSystem;
using RPGSandBox.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGSandBox.Controller
{
    public class PlayerActionSystem : PlayerControllerSystem
    {
        public static PlayerActionSystem instance { get; private set; }
        List<IAmAnAction> executableActions;
        public Action<object> OnMouseRightClick;
        public Action OnMouseLeftClick;
        public Action OnButtonClick;
        IAmAUnit currentUnit;
        private void Awake()
        {
            if(instance != null)
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
        public void ExecuteAction(IAmAnAction action, object target)
        {
            action.Execute(target);
            OnButtonClick?.Invoke();
            //currentUnit.Execute(action);
        }
        public List<IAmAnAction> ExecutableActions()
        {
            return executableActions;
        }
        void OnSelectedUnit()
        {
            currentUnit = UnitSelectionSystem.Instance.GetUnit();
            executableActions = currentUnit.MyActionsList();
        }

        public override void HandleLeftMouseDownStart()
        {
            if(!EventSystem.current.IsPointerOverGameObject())
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
            RaycastHit hit = MouseWorld.GetMouseRayCastHit();
            if(hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                OnMouseRightClick?.Invoke(interactable);
                return;
            }
            OnMouseRightClick?.Invoke(MouseWorld.GetMousePosition());
        }

        public override void HandleRightMouseDownMid()
        {
        }

        public override void HandleRightMouseDownEnd()
        {
        }
    }
}

