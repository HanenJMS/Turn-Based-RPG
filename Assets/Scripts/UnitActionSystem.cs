using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;
    public Action OnSelectedUnitChanged;
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
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            HandleUnitMovement();
        }
    }

    private void HandleUnitMovement()
    {
        if (selectedUnit != null)
        {
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            selectedUnit.Move(mouseGridPosition);
        }
    }

    bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask)) return false;
        if(hit.transform.TryGetComponent<Unit>(out Unit unit))
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
}
