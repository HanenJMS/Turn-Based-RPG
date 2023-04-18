using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    BaseAction currentAction = null;
    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;
    public Action OnSelectedUnitChanged;
    public Action OnSelectedActionChanged;
    public Action OnTimerPaused;

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
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (TryHandleSelection()) return;
        if (TryHandleUnitAction()) return;
    }

    private bool TryHandleUnitAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (selectedUnit == null)
            {
                return false;
            }
            if (currentAction == null) return false;
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            currentAction.Execute(mouseGridPosition);
            return true;
        }
        return false;
    }

    bool TryHandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask)) return false;
            if (!hit.transform.TryGetComponent<Unit>(out Unit unit)) return false;
            if(unit == selectedUnit) return false;
            SetSelectedUnit(unit);
            return true;
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        currentAction = null;
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

    internal void SetSelectedAction(BaseAction baseAction)
    {
        currentAction = baseAction;
        OnSelectedActionChanged?.Invoke();
    }
}
