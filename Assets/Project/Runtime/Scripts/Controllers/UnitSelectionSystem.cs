using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitSelectionSystem : PlayerControllerSystem
    {
        public static UnitSelectionSystem Instance { get; private set; }
        [SerializeField] private LayerMask layerMask;
        public Action OnSelectedUnit;
        IAmAUnit currentSelectedUnit;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        public void SetSelectedUnit(IAmAUnit selectingUnit)
        {
            if (currentSelectedUnit != selectingUnit)
            {
                UnitSelected(selectingUnit);
                currentSelectedUnit.Speak("Need Something?", true);
            }
        }
        void UnitSelected(IAmAUnit selectedUnit)
        {
            if (currentSelectedUnit == selectedUnit) return;
            currentSelectedUnit = selectedUnit;
            OnSelectedUnit?.Invoke();
        }
        public IAmAUnit GetUnit()
        {
            return currentSelectedUnit;
        }
        public override void HandleLeftMouseDownStart()
        {
            RaycastHit hit = MouseWorld.GetMouseRayCastHit();
            if(hit.transform.TryGetComponent(out IAmAUnit unit))
            {
                SetSelectedUnit(unit);
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
            
        }

        public override void HandleRightMouseDownMid()
        {
            
        }

        public override void HandleRightMouseDownEnd()
        {
            
        }
    }
}

