using RPGSandBox.GameUtilities.GridCore;
using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RPGSandBox.Controller
{
    public class RTSController_Old : MonoBehaviour
    {
        [SerializeField] private Transform selectionAreaTransform = null;
        [SerializeField] LayerMask unitLayerMask;
        Vector3 startPosition;
        bool isDragSelectionActive = false;

        private List<IAmAUnit_Old> selectedUnitList = new List<IAmAUnit_Old>();
        private void Awake()
        {
            selectionAreaTransform.gameObject.SetActive(false);
        }

        public bool HandleDragSelection()
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask)) return false;
                if (!hit.transform.TryGetComponent<IAmAUnit_Old>(out IAmAUnit_Old unit)) return false;
                AddUnitToList(unit);
                return true;

            }
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                selectionAreaTransform.gameObject.SetActive(true);
                startPosition = MouseWorld.GetMousePosition();
                isDragSelectionActive = true;
                DeselectAllUnits();
            }

            if (Input.GetMouseButton(0))
            {
                // Left Mouse Button Held Down
                float xAxis, zAxis;
                CalculateMouseDragPosition(out xAxis, out zAxis);
                Vector3 scale = new Vector3(xAxis, 1, zAxis);
                UpdateSelectionBox(scale);
            }
            if (Input.GetMouseButtonUp(0))
            {
                selectionAreaTransform.gameObject.SetActive(false);
                isDragSelectionActive = false;
            }
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                float xAxis, zAxis;
                CalculateMouseDragPosition(out xAxis, out zAxis);
                Vector3 scale = new Vector3(Mathf.Abs(xAxis), 1, Mathf.Abs(zAxis));
                Collider[] colliderArray = Physics.OverlapBox(selectionAreaTransform.position, scale * 0.5f);
                selectedUnitList.Clear();
                Debug.Log("######");
                UnitWithinOverLapBox(colliderArray);
                Debug.Log(selectedUnitList.Count);
            }
            return isDragSelectionActive;
        }
        public bool HandleUnitAction()
        {
            if (selectedUnitList.Count <= 0) return false;
            if (Input.GetMouseButtonDown(1))
            {
                TimeSystem.Instance.ExecuteSlowMotion(true);
                startPosition = MouseWorld.GetMousePosition();
            }
            if (Input.GetMouseButtonUp(1))
            {
                Queue<GridPosition> validGridPositionQueue = GetMoveToGridList();
                foreach (IAmAUnit_Old unit in selectedUnitList)
                {
                    unit.GetMoveAction().Execute(validGridPositionQueue.Dequeue());
                    //GridPosition moveToGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
                    //if (!LevelGrid.Instance.IsValidGridPosition(moveToGridPosition)) return false;
                    //unit.GetMoveAction().Execute(moveToGridPosition);
                }

                TimeSystem.Instance.ExecuteSlowMotion(false);
                return true;
            }
            return false;
        }
        public Queue<GridPosition> GetMoveToGridList()
        {
            Queue<GridPosition> validGridPositionQueue = new Queue<GridPosition>();
            GridPosition moveToMouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            int phalanxFormation = Mathf.RoundToInt(Mathf.Sqrt(selectedUnitList.Count));
            for (int u = 0, x = 0, z = 0; u < selectedUnitList.Count; u++)
            {
                int maxWidth = LevelGrid.Instance.GetGridWidth();
                int maxHeight = LevelGrid.Instance.GetGridHeight();
                int currentXPosition = moveToMouseGridPosition.x + x;
                int currentZPosition = moveToMouseGridPosition.z + z;
                if (currentXPosition >= maxWidth)
                {
                    currentXPosition = maxWidth - 1;
                }
                if (currentZPosition >= maxHeight)
                {
                    currentZPosition = maxHeight - 1;
                }
                if (currentXPosition < 0)
                {
                    currentXPosition = 0;
                }
                if (currentZPosition < 0)
                {
                    currentZPosition = 0;
                }
                if (currentXPosition < maxWidth && currentZPosition < maxHeight && currentXPosition >= 0 && currentZPosition >= 0)
                {
                    GridPosition gridPosition = new GridPosition(currentXPosition, currentZPosition);
                    validGridPositionQueue.Enqueue(gridPosition);
                }
                x++;
                if (x > phalanxFormation)
                {
                    z++;
                    x = 0;
                }
            }
            return validGridPositionQueue;
        }
        private void UnitWithinOverLapBox(Collider[] colliderArray)
        {
            foreach (Collider collider in colliderArray)
            {
                if (!collider.TryGetComponent(out IAmAUnit_Old unit)) continue;
                AddUnitToList(unit);
            }
        }

        private void AddUnitToList(IAmAUnit_Old unit)
        {
            if (selectedUnitList.Contains(unit)) return;
            selectedUnitList.Add(unit);
            unit.SetIsSelected(true);
        }

        public List<IAmAUnit_Old> GetSelectedUnits()
        {
            return selectedUnitList;
        }
        private void UpdateSelectionBox(Vector3 scale)
        {
            selectionAreaTransform.position = new Vector3((scale.x * 0.5f) + startPosition.x, 0.1f, (scale.z * 0.5f) + startPosition.z);
            selectionAreaTransform.localScale = scale;
        }

        private void CalculateMouseDragPosition(out float xAxis, out float zAxis)
        {
            xAxis = (MouseWorld.GetMousePosition().x - startPosition.x);
            zAxis = (MouseWorld.GetMousePosition().z - startPosition.z);
        }

        private void DeselectAllUnits()
        {
            foreach (IAmAUnit_Old unit in selectedUnitList)
            {
                unit.SetIsSelected(false);
            }

            selectedUnitList.Clear();
        }
    }
}

