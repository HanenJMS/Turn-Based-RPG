using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    int width;
    int height;
    float cellSize;
    Dictionary<GridPosition, GridObject> grid = new Dictionary<GridPosition, GridObject>();
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        for(int i = 0; i < width; i++)
        {
            for(int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(i, z);
                GridObject newGridTile = new GridObject(this, gridPosition);
                if(!grid.ContainsKey(gridPosition))
                {
                    grid.Add(gridPosition, newGridTile);
                    
                }
            }
        }
    }
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize));
    }
    public void CreateDebugObjects(Transform prefab)
    {
        for(int x = 0; x < width; x++)
        {
            for(int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform debugTransform = GameObject.Instantiate(prefab, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gdo = debugTransform.GetComponent<GridDebugObject>();
                gdo.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }
    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return grid[gridPosition];
    }
    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        if(gridPosition == null) return false;
        return grid.ContainsKey(gridPosition);
    }    
}
