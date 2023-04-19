using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected Unit unit { get; private set; }
    
    [SerializeField] Animator animator;
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
    private void Update()
    {
        if (!IsRunning()) return;
        PerformLogic();
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
    public abstract string GetActionName();
    public abstract List<GridPosition> GetValidGridPositionList();
    public abstract bool IsRunning();
    public abstract void Execute(GridPosition gridPosition);
    public abstract void Cancel();
    protected abstract void PerformLogic();
    
}
