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
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }
    void UnitActionSystem_OnSelectedUnitChanged()
    {
        UpdateVisual();
    }
    void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnitList().Contains(unit))
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }
    private void OnDestroy()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= UnitActionSystem_OnSelectedUnitChanged;
    }
}
