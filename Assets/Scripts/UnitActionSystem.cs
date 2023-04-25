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
    List<BaseAction> unitActionList = new List<BaseAction>();
    [SerializeField] RTSController controller;
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
        controller = GetComponentInChildren<RTSController>();
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
        return controller.HandleUnitAction();
    }


    bool TryHandleSelection()
    {
        return controller.HandleDragSelection();
    }

    private void AddUnitAction(Unit unit)
    {
        unitActionList.Add(unit.GetMoveAction());
        OnSelectedUnitChanged?.Invoke();
    }
    public Unit GetSelectedUnit()
    {
        if (selectedUnitList != null && selectedUnitList.Count > 0)
            return selectedUnitList[0];
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
