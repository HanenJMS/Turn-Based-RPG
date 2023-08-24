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
        public static PlayerActionController Instance { get; private set; }
        public Action<object> OnMouseRightClick;
        public Action OnMouseLeftClick;
        public Action OnButtonClick;
        public Action<object> playerStartsTrade;
        IAmAUnit currentUnit;
        List<IAmAnAction> actionList;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }
        //MODIFY MODIFY MODIFY MODIFY MODIFY!!!!!!! Player Controller enters here. You can have it launch the UI and let the UI Execute the command.
        public void ExecuteAction(IAmAnAction action, object target)
        {
            if(action is ICanTrade)
            {
                playerStartsTrade?.Invoke(target);
            }
            if(action is ICanMove)
            {
                PlayerStartsUnit(action, target);
            }
            if (action is ICanGather)
            {
                PlayerStartsUnit(action, target);
            }
            if(action is ICanCraft)
            {
                PlayerStartsUnit(action, target);
            }
            OnButtonClick?.Invoke();
        }

        private void PlayerStartsUnit(IAmAnAction action, object target)
        {
            action.Execute(target);
            
            currentUnit.Execute(action);
        }

        public List<IAmAnAction> ExecutableActions() => currentUnit.ActionList();
        //{
        //    return executableActions;
        //}
        public void OnSelectedUnit()
        {
            currentUnit = UnitSelectionSystem.Instance.GetUnit();
            //executableActions = currentUnit.ActionList();
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
            if (currentUnit == null) return;
            if (hit.transform.TryGetComponent(out IAmInteractable interactable))
            {
                OnMouseRightClick?.Invoke(interactable);
                return;
            }
            OnMouseRightClick?.Invoke(MouseWorld.GetMousePosition());
        }
    }
}

