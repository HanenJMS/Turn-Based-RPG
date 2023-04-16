using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition currentGridPosition;
    MoveAction moveAction;
    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
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
    public void Move(GridPosition destination)
    {
        moveAction.Move(destination);
    }
    public BaseAction GetBaseAction()
    {
        return moveAction;
    }
    public GridPosition GetUnitGridPosition()
    {
        return currentGridPosition;
    }
}
