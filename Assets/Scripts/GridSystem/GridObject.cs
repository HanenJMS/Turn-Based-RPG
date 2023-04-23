using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridObject
{
    GridSystem gridSystem;
    GridPosition gridPosition;
    GridPosition gridPositionAbove, gridPositionLeft, gridPositionRight, gridPositionBelow;
    List<GridPosition> AdjacentGrids;
    List<GameObject> gameObjects;
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        gridPositionAbove = new GridPosition(gridPosition.x, gridPosition.z + 1);
        gridPositionBelow = new GridPosition(gridPosition.x, gridPosition.z - 1);
        gridPositionLeft = new GridPosition(gridPosition.x - 1, gridPosition.z - 1);
        gridPositionRight = new GridPosition(gridPosition.x + 1, gridPosition.z);
        AdjacentGrids = new List<GridPosition>
        {
            gridPositionAbove,
            gridPositionBelow,
            gridPositionLeft,
            gridPositionRight
        };

        gameObjects = new List<GameObject>();
    }
    public void AddObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }
    public List<GameObject> GetGameObjects()
    {
        return gameObjects;
    }

    public void RemoveGameObject(GameObject gameObject)
    {
        if(gameObjects.Contains(gameObject))
        {
            gameObjects.Remove(gameObject);
        }    
    }
    public bool HasObject()
    {
        return gameObjects.Count > 0;
    }
    public List<GridPosition> GetAdjacentGridPosition()
    {
        return AdjacentGrids;
    }
    public override string ToString()
    {
        string gameObjectNames = "";
        foreach(GameObject gameObject in gameObjects)
        {
            gameObjectNames += $"{gameObject}\n";
        }
        return gridPosition.ToString() + $"\n{gameObjectNames}"; 
    }
}
