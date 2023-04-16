using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveAction : BaseAction
{
    Vector3 targetPosition;
    [SerializeField] int maxMoveDistance = 5;
    float rotationSpeed = 50f;
    float stoppingDistance = 0.01f;
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
        if (!IsWithinDistance())
        {
            GetAnimator().SetBool("isRunning", true);
            return true;
        }
        else
        {
            GetAnimator().SetBool("isRunning", false);
        }
        return false;
    }

    protected override void PerformLogic()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public override List<GridPosition> GetValidGridPositionList()
    {
        List<GridPosition> validGridPositions = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetUnitGridPosition(); 
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition validatingGridPosition = unitGridPosition + offsetGridPosition;
                if (!LevelGrid.Instance.IsValidGridPosition(validatingGridPosition)) continue;
                if(unitGridPosition ==  validatingGridPosition) continue;
                if(LevelGrid.Instance.HasObjectOnGridPosition(validatingGridPosition)) continue;
                validGridPositions.Add(validatingGridPosition);
            }
        }
        return validGridPositions;
    }
    bool IsWithinDistance()
    {
        return Vector3.Distance(transform.position, targetPosition) <= stoppingDistance;
    }
    public bool Move(GridPosition destination)
    {
        if (!IsValidActionGridPosition(destination)) return false;
        targetPosition = LevelGrid.Instance.GetWorldPosition(destination);
        if (targetPosition == null) return false;
        return IsRunning();
    }
}
