using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    public Unit unit { get; private set; }
    [SerializeField] Animator animator;
    private void Awake()
    {
        unit = GetComponent<Unit>();
    }
    public Animator GetAnimator() 
    {
        return  animator; 
    }
    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }
    public abstract List<GridPosition> GetValidGridPositionList();
}
