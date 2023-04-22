using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridObject
{
    GridSystem gridSystem;
    GridPosition gridPosition;
    List<GameObject> gameObjects;
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
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
