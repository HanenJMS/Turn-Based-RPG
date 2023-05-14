using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridValidation
{
    public List<GridPosition> GetValidGridPositionList()
    {
        List<GridPosition> validGridPositions = new List<GridPosition>();
        //for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        //{
        //    for(int z = -maxMoveDistance; z <= maxMoveDistance; z++)
        //    {
        //        GridPosition offsetGridPosition = new GridPosition(x, z);
        //        validGridPositions.Add(offsetGridPosition);
        //    }
        //}
        return validGridPositions;
    }

    public void ValidateGridPosition()
    {

    }
}
