using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    BaseAction currentAction = null;
    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;
    public Action OnSelectedUnitChanged;
    bool isBusy = false;
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
            if (currentAction.IsRunning()) return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            currentAction = selectedUnit.GetMoveAction();
            TryHandleUnitMovement();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAction = selectedUnit.GetSpinAction();
            selectedUnit.GetSpinAction().Spin();
        }
    }

    private bool TryHandleUnitMovement()
    {
        if (selectedUnit == null)
        {
            return false;
        }
        GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
        return selectedUnit.Move(mouseGridPosition);
    }

    bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask)) return false;
        if (hit.transform.TryGetComponent<Unit>(out Unit unit))
        {
            SetSelectedUnit(unit);
            return true;
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke();
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    public BaseAction GetCurrentAction()
    {
        return currentAction;
    }
}
