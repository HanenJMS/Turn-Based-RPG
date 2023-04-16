using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] Unit unit;
    private void Update()
    {
        List<GridPosition> list = new List<GridPosition>();
        if(Input.GetKeyDown(KeyCode.T))
        {
            unit.GetBaseAction().GetValidGridPositionList();
        }
    }
}
