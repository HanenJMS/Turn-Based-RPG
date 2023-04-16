using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    [SerializeField] Transform prefab;
    
    GridSystem gridSystem;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(10, 10, 2f);
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
        gridObject.AddUnit(unit);
    }
    public List<Unit> GetUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnits();
    }
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
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
        return gridObject.HasUnits();
    }
}

