using RPGSandBox.InterfaceSystem;
using RPGSandBox.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.Controller
{
    public class PlayerActionSystem : PlayerControllerSystem
    {
        public static PlayerActionSystem instance { get; private set; }
        List<IAmAnAction> executableActions;
        public Action OnMouseRightClick;
        IAmAUnit unit;
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
        public void ExecuteAction(IAmAnAction action)
        {

        }
        public List<IAmAnAction> ExecutableActions()
        {
            return executableActions;
        }
        void OnSelectedUnit()
        {
            unit = UnitSelectionSystem.Instance.GetUnit();
            
        }

        public override void HandleLeftMouseDownStart()
        {

        }

        public override void HandleLeftMouseDownMid()
        {
        }

        public override void HandleLeftMouseDownEnd()
        {
        }

        public override void HandleRightMouseDownStart()
        {
            OnMouseRightClick?.Invoke();
        }

        public override void HandleRightMouseDownMid()
        {
        }

        public override void HandleRightMouseDownEnd()
        {
        }
    }
}

