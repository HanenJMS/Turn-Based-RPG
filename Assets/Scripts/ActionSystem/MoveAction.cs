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
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsWithinDistance())
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
            GetAnimator().SetBool("isRunning", true);

        }
        else
        {
            GetAnimator().SetBool("isRunning", false);
        }
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
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
    public void Move(GridPosition destination)
    {
        if (!IsValidActionGridPosition(destination)) return;
        targetPosition = LevelGrid.Instance.GetWorldPosition(destination);
        
    }
}
