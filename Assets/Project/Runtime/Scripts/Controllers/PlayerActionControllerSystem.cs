using RPGSandBox.InterfaceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGSandBox.Controller
{
    public class PlayerActionControllerSystem : MouseInputController
    {
        public static PlayerActionControllerSystem Instance { get; private set; }
        public Action<object> OnMouseRightClick;
        public Action OnMouseLeftClick;
        public Action OnButtonClick;


        public Action<object> playerStartsTrade;
        public Action playerStartsCraft;
        IAmAUnit playerSelectedUnit;
        object playerTarget;
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
        
        public void ExecuteAction(IAmAnAction action, object target)
        {
            playerTarget = target;
            if (action is ICanTrade)
            {
                playerStartsTrade?.Invoke(playerTarget);
            }
            if (action is ICanMove)
            {
                PlayerStartsActions(action, playerTarget);
            }
            if (action is ICanGather)
            {
                PlayerStartsActions(action, playerTarget);
            }
            if (action is ICanCraft)
            {
                PlayerStartsActions(action, playerTarget);
            }
            OnButtonClick?.Invoke();
        }

        private void PlayerStartsActions(IAmAnAction action, object target)
        {
            action.Execute(target);

            playerSelectedUnit.Execute(action);
        }

        public List<IAmAnAction> ExecutableActions()
        {
            return playerSelectedUnit.ActionList();
        }

        //{
        //    return executableActions;
        //}
        public void OnSelectedUnit()
        {
            playerSelectedUnit = UnitSelectionSystem.Instance.GetUnit();
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
            if (playerSelectedUnit == null) return;
            //if (EventSystem.current.IsPointerOverGameObject()) return;
            if (hit.transform.TryGetComponent(out IAmInteractable interactableTarget))
            {
                OnMouseRightClick?.Invoke(interactableTarget);
                return;
            }
            OnMouseRightClick?.Invoke(MouseWorld.GetMousePosition());
        }
    }
}

