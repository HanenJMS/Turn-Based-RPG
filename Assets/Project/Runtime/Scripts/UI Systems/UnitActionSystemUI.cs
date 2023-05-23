using RPGSandBox.InterfaceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] Transform actionButtonPrefab;
    [SerializeField] Transform actionButtonContainer;
    List<ActionButtonUI> actionButtons = new List<ActionButtonUI>();
    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UnitActionSystem.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        CreateActionButtons();
    }
    private void UnitActionSystem_OnSelectedUnitChanged()
    {
        CreateActionButtons();
    }
    void UnitActionSystem_OnSelectedActionChanged()
    {
        foreach(ActionButtonUI actionButton in actionButtons)
        {
            actionButton.UnitActionSystem_OnSelectedUnitChanged();
        }
    }
    void CreateActionButtons()
    {
        ClearActionBar();
        IAmAUnit_Old selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        if (selectedUnit == null) { return; }
        foreach (BaseAction action in selectedUnit.GetActionList())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainer);
            ActionButtonUI actionButton = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButton.SetBaseAction(action);
            actionButton.UnitActionSystem_OnSelectedUnitChanged();
            actionButtons.Add(actionButton);
        }
    }

    private void ClearActionBar()
    {
        foreach (Transform buttons in actionButtonContainer)
        {
            Destroy(buttons.gameObject);
        }
        actionButtons.Clear();
    }
}
