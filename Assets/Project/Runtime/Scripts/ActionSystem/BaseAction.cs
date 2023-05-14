using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected Unit unit { get; private set; }
    protected bool isRunning = true;
    
    [SerializeField] UnitAnimatorController animatorController;
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
    private void FixedUpdate()
    {
        if (!isRunning)
        {
            Cancel();
            return;
        }
        isRunning = IsRunning();
        PerformLogic();
    }
    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }
    public void SetAnimation(string animationName, bool animationRunningState)
    {
        animatorController.SetAnimation(animationName, animationRunningState);
    }
    public abstract string GetActionName();
    public abstract List<GridPosition> GetValidGridPositionList();
    public abstract bool IsRunning();
    public abstract void Execute(GridPosition gridPosition);
    public virtual void Cancel()
    {
        isRunning = false;
    }
    protected abstract void PerformLogic();
}
