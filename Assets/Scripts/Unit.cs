using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition currentGridPosition;
    public Action OnUnitSelected;
    List<BaseAction> actions;
    bool isSelected = false;
    private void Awake()
    {
        actions = new List<BaseAction>(GetComponents<BaseAction>()); 
    }
    private void Start()
    {
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);
    }
    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != currentGridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
    }
    public List<BaseAction> GetActionList()
    {
        return actions;
    }
    public GridPosition GetUnitGridPosition()
    {
        return currentGridPosition;
    }
    public BaseAction GetMoveAction()
    {
        BaseAction moveAction = null;
        if (actions.Count <= 0)
        {
            Debug.Log($"Missing MoveAction on {this.transform.name} on {this.transform.position}");
            return moveAction;
        }
        foreach(BaseAction action in actions)
        {
            if(action is MoveAction)
            {
                moveAction = action;
                return action;
            }
        }
        return moveAction;
    }

    public void MoveTo(GridPosition destination)
    {
        GetMoveAction().Execute(destination);
    }
    public void SetIsSelected(bool isSelected)
    {
        this.isSelected = isSelected;
        OnUnitSelected?.Invoke();
    }
    public bool IsSelected()
    {
        return isSelected;
    }
}
