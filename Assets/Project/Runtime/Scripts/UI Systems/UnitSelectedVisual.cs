using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] Unit unit;
    MeshRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        unit = GetComponentInParent<Unit>();
    }
    private void Start()
    {
        unit.OnUnitSelected += UnitOnUnitSelected_OnUnitSelected;
        UpdateVisual();
    }
    void UnitOnUnitSelected_OnUnitSelected()
    {
        UpdateVisual();
    }
    void UpdateVisual()
    {
        renderer.enabled = unit.IsSelected();
    }
    private void OnDestroy()
    {
        unit.OnUnitSelected -= UnitOnUnitSelected_OnUnitSelected;
    }
}
