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
        void Update()
        {
            // Handle unit selection
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = MouseWorld.GetMouseRayCastHit();

                if (hit.transform.TryGetComponent(out IAmAUnit selectedUnit))
                {
                    if (currentSelectedUnit != selectedUnit)
                    {
                        UnitSelected(selectedUnit);
                        currentSelectedUnit.Speak("Need Something?", true);
                    }

                }

                if (hit.transform.TryGetComponent(out IAmAUnit unit))
                {
                    if (currentSelectedUnit == unit)
                    {
                        int random = UnityEngine.Random.Range(0, 3);
                        if (random == 0)
                        {
                            currentSelectedUnit.Speak("what?", false);
                        }
                        if (random == 1)
                        {
                            currentSelectedUnit.Speak("quit it!", false);
                        }
                        if (random == 2)
                        {
                            currentSelectedUnit.Speak("stop poking me!", false);

                        }

                    }
                }
            }

            //Handle Unit Movement
            if (Input.GetMouseButton(1))
            {
                if (currentSelectedUnit != null)
                {
                    currentSelectedUnit.SetToMove(MouseWorld.GetMousePosition());
                    currentSelectedUnit.Speak("Ok! got it! moving to location.", true);
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                RaycastHit hit = MouseWorld.GetMouseRayCastHit();
                if (currentSelectedUnit != null)
                {
                    if (hit.transform.TryGetComponent<IAmAnItem>(out IAmAnItem item))
                    {
                        currentSelectedUnit.Gather(item);
                    }
                    if (hit.transform.TryGetComponent<IAmACraftingStation>(out IAmACraftingStation station))
                    {
                        currentSelectedUnit.Craft(station);
                    }
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
            OnSelectedUnit?.Invoke();
        }
    }
}

