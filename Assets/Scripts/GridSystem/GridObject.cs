using System.Collections.Generic;
using System.Linq;

public class GridObject
{
    GridSystem gridSystem;
    GridPosition gridPosition;
    List<Unit> units;
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        units = new List<Unit>();
    }
    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }
    public List<Unit> GetUnits()
    {
        return units;
    }

    public void RemoveUnit(Unit unit)
    {
        if(units.Contains(unit))
        {
            units.Remove(unit);
        }    
    }
    public override string ToString()
    {
        string unitNames = "";
        foreach(Unit unit in units)
        {
            unitNames += $"{unit}\n";
        }
        return gridPosition.ToString() + $"\n{unitNames}"; 
    }
}
