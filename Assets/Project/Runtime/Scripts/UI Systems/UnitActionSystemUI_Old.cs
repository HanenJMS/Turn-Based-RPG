using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI_Old : MonoBehaviour
{
    [SerializeField] Transform actionButtonPrefab;
    [SerializeField] Transform actionButtonContainer;
    List<ActionButtonUI_Old> actionButtons = new List<ActionButtonUI_Old>();
    private void Start()
    {
        UnitActionSystem_Old.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UnitActionSystem_Old.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        CreateActionButtons();
    }
    private void UnitActionSystem_OnSelectedUnitChanged()
    {
        CreateActionButtons();
    }
    void UnitActionSystem_OnSelectedActionChanged()
    {
        foreach (ActionButtonUI_Old actionButton in actionButtons)
        {
            actionButton.UnitActionSystem_OnSelectedUnitChanged();
        }
    }
    void CreateActionButtons()
    {
        ClearActionBar();
        IAmAUnit_Old selectedUnit = UnitActionSystem_Old.Instance.GetSelectedUnit();
        if (selectedUnit == null) { return; }
        foreach (BaseAction action in selectedUnit.GetActionList())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainer);
            ActionButtonUI_Old actionButton = actionButtonTransform.GetComponent<ActionButtonUI_Old>();
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
