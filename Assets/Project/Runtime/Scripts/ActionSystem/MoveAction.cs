using RPGSandBox.GameUtilities.GridCore;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    Vector3 targetPosition;
    float rotationSpeed = 50f;
    float stoppingDistance = 0.1f;
    float moveSpeed = 5.5f;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    // Update is called once per frame

    public override bool IsRunning()
    {
        if (IsWithinDistance())
        {
            GridPosition currentPosition = unit.GetUnitGridPosition();
            List<GridPosition> gridPositionList = LevelGrid.Instance.GetGridObjects()[currentPosition].GetAdjacentGridPosition();
            List<GameObject> gameObjectsOnGrid = LevelGrid.Instance.GetObjectsAtGridPosition(currentPosition);

            if (gameObjectsOnGrid == null) { return false; }
            if (gameObjectsOnGrid.Count <= 0) { return false; }
            if (gameObjectsOnGrid[0] != this.gameObject)
            {
                foreach (GridPosition gridPosition in gridPositionList)
                {
                    if (!LevelGrid.Instance.GetGridObjects()[gridPosition].HasObject())
                    {
                        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
                        return true;
                    }
                }
                GridPosition getNextGridPosition = LevelGrid.Instance.GetGridObjects()[currentPosition].GetNextGridPosition();
                targetPosition = LevelGrid.Instance.GetWorldPosition(getNextGridPosition);
                return true;
            }

            StopRunning();
            return false;
        }
        else
        {
            StartRunning();
            return true;
        }
    }

    private void StartRunning()
    {
        SetAnimation("isRunning", true);
    }
    private void StopRunning()
    {
        SetAnimation("isRunning", false);
    }
    protected override void PerformLogic()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }
    public override void Cancel()
    {
        base.Cancel();
        StopRunning();
    }
    public override List<GridPosition> GetValidGridPositionList()
    {
        List<GridPosition> validGridPositions = new List<GridPosition>();
        GridPosition moveToMouseGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        foreach (KeyValuePair<GridPosition, GridObject> gp in LevelGrid.Instance.GetGridObjects())
        {
            if (LevelGrid.Instance.HasObjectOnGridPosition(gp.Key)) continue;
            if (moveToMouseGridPosition == gp.Key) continue;
            validGridPositions.Add(gp.Key);
        }
        return validGridPositions;
    }

    bool IsWithinDistance()
    {
        return Vector3.Distance(transform.position, targetPosition) <= stoppingDistance;
    }
    bool Move(GridPosition destination)
    {
        targetPosition = LevelGrid.Instance.GetWorldPosition(destination);
        if (targetPosition == null) return false;
        return IsRunning();
    }
    public override string GetActionName()
    {
        return "Move";
    }

    public override void Execute(GridPosition destination)
    {
        isRunning = Move(destination);
    }
}
