using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitSelectionSystem : MonoBehaviour
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
        private void Update()
        {
            // Handle unit selection
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = MouseWorld.GetMouseRayCastHit();
                if(hit.transform.TryGetComponent(out IAmAUnit selectedUnit))
                {
                    UnitSelected(selectedUnit);
                }
            }

            //Handle Unit Movement
            if (Input.GetMouseButton(1))
            {
                RaycastHit hit = MouseWorld.GetMouseRayCastHit();

                if(hit.transform.TryGetComponent(out IAmAUnit unit))
                {
                    if(currentSelectedUnit == unit)
                    {
                        int random = UnityEngine.Random.Range(0, 3);
                        if (random == 0)
                        {
                            currentSelectedUnit.Speak("what?");
                            return;
                        }
                        if (random == 1)
                        {
                            currentSelectedUnit.Speak("quit it!");
                            return;
                        }
                        if(random == 2)
                        {
                            currentSelectedUnit.Speak("stop poking me!");
                            return;
                        }
                        
                    }
                    return;
                }
             
                if (currentSelectedUnit != null)
                {
                    currentSelectedUnit.Move(MouseWorld.GetMousePosition());
                    currentSelectedUnit.Speak("Ok! got it! moving to location.");
                }
            }
        }
        public IAmAUnit GetUnit()
        {
            return currentSelectedUnit;
        }
        void UnitSelected(IAmAUnit selectedUnit)
        {
            if (currentSelectedUnit == selectedUnit) return;
            currentSelectedUnit = selectedUnit;
            currentSelectedUnit.Speak("Yes? You need something?");
            OnSelectedUnit?.Invoke();
        }
    }
}

