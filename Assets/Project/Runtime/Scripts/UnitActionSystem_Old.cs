using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem_Old : MonoBehaviour
{
    public static UnitActionSystem_Old Instance { get; private set; }
    BaseAction currentAction = null;
    List<BaseAction> unitActionList = new List<BaseAction>();
    [SerializeField] RTSController_Old controller;
    [SerializeField] IAmAUnit_Old selectedUnit;
    [SerializeField] List<IAmAUnit_Old> selectedUnitList = new List<IAmAUnit_Old>();
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
        controller = GetComponentInChildren<RTSController_Old>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAction != null)
        {

        }
        if (EventSystem.current.IsPointerOverGameObject())
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

    private void AddUnitAction(IAmAUnit_Old unit)
    {
        unitActionList.Add(unit.GetMoveAction());
        OnSelectedUnitChanged?.Invoke();
    }
    public IAmAUnit_Old GetSelectedUnit()
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
