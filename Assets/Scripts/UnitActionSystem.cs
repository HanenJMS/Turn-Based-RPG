using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    BaseAction currentAction = null;
    [SerializeField] Unit selectedUnit;
    [SerializeField] List<Unit> selectedUnitList = new List<Unit>();
    [SerializeField] LayerMask unitLayerMask;
    public Action OnSelectedUnitChanged;
    public Action OnSelectedActionChanged;
    public Action OnTimerPaused;

    //selection system
    Vector3 startPosition;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAction != null)
        {
            
        }
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (TryHandleSelection()) return;
        if (TryHandleUnitAction()) return;
    }

    private bool TryHandleUnitAction()
    {
        if (selectedUnit == null)
        {
            return false;
        }
        if (currentAction == null) return false;
        return HandleUnitActionExecute();
    }

    private bool HandleUnitActionExecute()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TimeSystem.Instance.ExecuteSlowMotion(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            //if (currentAction != selectedUnit.GetMoveAction())
            //{
            //    selectedUnit.GetMoveAction().Cancel();
            //}
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            currentAction.Execute(mouseGridPosition);
            TimeSystem.Instance.ExecuteSlowMotion(false);
            return true;
        }
        return false;
    }

    bool TryHandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = MouseWorld.GetMousePosition();
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            Collider[] colliderArray = Physics.OverlapBox(startPosition, MouseWorld.GetMousePosition(), Quaternion.identity, unitLayerMask);
            selectedUnitList.Clear();
            Debug.Log(colliderArray.Length);
            foreach(Collider collider in colliderArray)
            {
                if (!collider.TryGetComponent<Unit>(out Unit unit)) continue;
                selectedUnitList.Add(unit);
            }
            Debug.Log(selectedUnitList.Count);
            if (selectedUnitList.Count > 0) return true;
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        currentAction = unit.GetMoveAction();
        OnSelectedUnitChanged?.Invoke();
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    public List<Unit> GetSelectedUnitList()
    {
        return selectedUnitList;
    }
    public BaseAction GetCurrentAction()
    {
        return currentAction;
    }

    internal void SetSelectedAction(BaseAction baseAction)
    {
        currentAction = baseAction;
        OnSelectedActionChanged?.Invoke();
    }
}
