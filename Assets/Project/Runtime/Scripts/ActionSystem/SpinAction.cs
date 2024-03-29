using RPGSandBox.GameUtilities.GridCore;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    float totalSpinAmount = 360f;
    float currentSpunAmount = float.MaxValue;

    public override List<GridPosition> GetValidGridPositionList()
    {
        return new List<GridPosition>
        {
            unit.GetUnitGridPosition()
        };
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

    public bool Spin(GridPosition gridPosition)
    {
        if (!IsValidActionGridPosition(gridPosition)) return false;
        currentSpunAmount = 0f;
        return IsRunning();
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override void Execute(GridPosition gridPosition)
    {
        isRunning = Spin(gridPosition);
    }
}
