using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootAction : BaseAction
{
    [SerializeField] int shootRange = 5;
    Vector3 targetPosition;
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
                if (!LevelGrid.Instance.IsValidGridPosition(validatingGridPosition)) continue;
                if (unitGridPosition == validatingGridPosition) continue;
                if (LevelGrid.Instance.HasObjectOnGridPosition(validatingGridPosition)) continue;
                validGridPositions.Add(validatingGridPosition);
            }
        }
        return validGridPositions;
    }
    public override bool IsRunning()
    {
        
        return false;
    }
    bool IsWithinDistance()
    {
        return Vector3.Distance(transform.position, targetPosition) <= shootRange;
    }
    public override void Execute(GridPosition gridPosition)
    {

    }
    protected override void PerformLogic()
    {

    }
    bool Shoot(GridPosition gridPosition)
    {
        
        return IsRunning();
    }

    public override void Cancel()
    {
        throw new System.NotImplementedException();
    }
}
