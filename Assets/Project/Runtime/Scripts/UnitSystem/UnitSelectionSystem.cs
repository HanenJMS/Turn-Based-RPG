using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSelectionSystem
{
    public class UnitSelectionSystem : MonoBehaviour
    {
        public static UnitSelectionSystem Instance { get; private set; }
        [SerializeField] private LayerMask layerMask;

        [SerializeField] IAmAUnit selectedUnit;
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
                if (selectedUnit == null)
                {
                    RaycastHit hit = MouseWorld.GetMouseRayCastHit();

                    if(hit.transform.TryGetComponent<IAmAUnit>(out selectedUnit))
                    {
                        selectedUnit.OnSelected();
                    }
                }
            }

            //Handle Unit Movement
            if (Input.GetMouseButton(1))
            {
                if (selectedUnit != null)
                {
                    selectedUnit.MoveToDestination(MouseWorld.GetMousePosition());
                }
            }
        }
        public bool SetSelectedUnit(IAmAUnit unit)
        {
            selectedUnit = unit;
            return false;
        }
    }
}

