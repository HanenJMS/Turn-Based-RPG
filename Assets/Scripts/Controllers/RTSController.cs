using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RTSController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform = null;
    [SerializeField] LayerMask unitLayerMask;
    Vector3 startPosition;
    bool isDragSelectionActive = false;

    private List<Unit> selectedUnitList = new List<Unit>();
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
            if (!hit.transform.TryGetComponent<Unit>(out Unit unit)) return false;
            AddUnitToList(unit);
            return true;

        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = MouseWorld.GetMousePosition();
            isDragSelectionActive= true;
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
            foreach (Unit unit in selectedUnitList)
            {
                unit.GetMoveAction().Execute(validGridPositionQueue.Dequeue());
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
        for(int u = 0, x = 0,z = 0; u < selectedUnitList.Count; u++)
        {
            GridPosition gridPosition = new GridPosition(moveToMouseGridPosition.x + x, moveToMouseGridPosition.z + z);
            validGridPositionQueue.Enqueue(gridPosition);
            x++;
            if(x > phalanxFormation)
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
            if (!collider.TryGetComponent(out Unit unit)) continue;
            AddUnitToList(unit);
        }
    }

    private void AddUnitToList(Unit unit)
    {
        if(selectedUnitList.Contains(unit)) return;
        selectedUnitList.Add(unit);
        unit.SetIsSelected(true);
    }

    public List<Unit> GetSelectedUnits()
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
        foreach (Unit unit in selectedUnitList)
        {
            unit.SetIsSelected(false);
        }

        selectedUnitList.Clear();
    }
}
