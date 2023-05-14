using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    [SerializeField] Transform prefab;
    [SerializeField] int gridWidth = 10, gridHeight = 10;
    [SerializeField] float cellSize = 2f;
    GridSystem gridSystem;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(gridWidth, gridHeight, cellSize);
        gridSystem.CreateDebugObjects(prefab);
    }
    private void Start()
    {

    }
    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetMousePosition()));
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddObject(unit.gameObject);
    }
    public List<GameObject> GetObjectsAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetGameObjects();
    }
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveGameObject(unit.gameObject);
    }
    public void UnitMovedGridPosition(Unit unit, GridPosition fromPosition, GridPosition toPosition)
    {
        RemoveUnitAtGridPosition(fromPosition, unit);
        AddUnitAtGridPosition(toPosition, unit);
    }
    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridSystem.IsValidGridPosition(gridPosition);
    }
    
    public bool HasObjectOnGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasObject();
    }
    public Dictionary<GridPosition, GridObject> GetGridObjects() => gridSystem.GetGridObjects();
    public float GetCellSize()
    {
        return cellSize;
    }
    public int GetGridWidth()
    {
        return gridWidth;
    }
    public int GetGridHeight()
    {
        return gridHeight;
    }
}

