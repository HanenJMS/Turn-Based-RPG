using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ShootAction : BaseAction
{
    [SerializeField] int shootRange = 5;
    Unit unitTarget;
    Vector3 targetPosition;
    float totalSpinAmount = 360f;
    float currentSpunAmount = float.MaxValue;
    public override string GetActionName()
    {
        return "Shoot";
    }
    public override List<GridPosition> GetValidGridPositionList()
    {
        List<GridPosition> validGridPositions = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetUnitGridPosition();
        for (int x = -shootRange; x <= shootRange; x++)
        {
            for (int z = -shootRange; z <= shootRange; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition validatingGridPosition = unitGridPosition + offsetGridPosition;
                int testDistance = Mathf.Abs(x) + Mathf.Abs(z);
                if (testDistance > shootRange) continue;
                if (!LevelGrid.Instance.IsValidGridPosition(validatingGridPosition)) continue;
                if (unitGridPosition == validatingGridPosition) continue;
                if (!LevelGrid.Instance.HasObjectOnGridPosition(validatingGridPosition)) continue;
                if (!LevelGrid.Instance.GetGridObjects()[validatingGridPosition].GetUnits()[0] == unit) continue;
                validGridPositions.Add(validatingGridPosition);
            }
        }
        return validGridPositions;
    }
    public override void Execute(GridPosition gridPosition)
    {
        isRunning = Shoot(gridPosition);
    }
    bool Shoot(GridPosition gridPosition)
    {
        if (!IsValidActionGridPosition(gridPosition)) return false;
        currentSpunAmount = 0f;
        return IsRunning();
    }
    public override bool IsRunning()
    {
        return currentSpunAmount < totalSpinAmount;
    }
    protected override void PerformLogic()
    {
        float spinAddAmount = 360f * Time.deltaTime;

        currentSpunAmount += spinAddAmount;
        currentSpunAmount = Mathf.Clamp(currentSpunAmount, 0, totalSpinAmount);
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
    }

}
