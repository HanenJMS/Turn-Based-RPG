using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    GridObject grid;
    [SerializeField] TextMeshPro textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }
    public void SetGridObject(GridObject gridObject)
    {
        grid = gridObject;
    }
    private void Update()
    {
        textMeshPro.text = grid.ToString();
    }
}
