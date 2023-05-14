using System.Collections.Generic;
using UnityEngine;

public class ShootAction : BaseAction
{
    [SerializeField] int shootRange = 5;
    Unit unitTarget;
    Vector3 targetPosition;
    float rotationSpeed = 10f;
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
                //if (.Contains(unit)) continue;
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
        unitTarget = LevelGrid.Instance.GetGridObjects()[gridPosition].GetGameObjects()[0].GetComponent<Unit>();

        return IsRunning();
    }
    public override bool IsRunning()
    {
        if (unitTarget != null) return true;
        if (unitTarget == null) return false;
        return false;
    }
    protected override void PerformLogic()
    {
        Vector3 facingDirection = (unitTarget.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, facingDirection, Time.deltaTime * rotationSpeed);
    }
    public override void Cancel()
    {
        base.Cancel();
        unitTarget = null;
    }
}
