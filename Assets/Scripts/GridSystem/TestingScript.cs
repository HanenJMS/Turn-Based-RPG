using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] Transform prefab;
    GridSystem gridSystem;
    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(prefab);
    }
    private void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetMousePosition()));
    }
}
