using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition currentGridPosition;
    List<BaseAction> actions;
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
}
