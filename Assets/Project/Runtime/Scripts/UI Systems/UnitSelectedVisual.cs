using RPGSandBox.InterfaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] IAmAUnit unit;
    MeshRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        unit = GetComponentInParent<IAmAUnit>();
    }
    private void Update()
    {
       UpdateVisual();
    }
    void UpdateVisual()
    {
        renderer.enabled = unit.IsSelected();
    }
    private void OnDestroy()
    {
        //unit.OnUnitSelected -= UnitOnUnitSelected_OnUnitSelected;
    }
}
