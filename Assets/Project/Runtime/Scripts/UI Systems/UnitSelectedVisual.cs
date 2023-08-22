using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] IAmAUnit unit;
    [SerializeField] MeshRenderer selectionRenderer;
    private void Awake()
    {
        selectionRenderer = GetComponent<MeshRenderer>();
        unit = GetComponentInParent<IAmAUnit>();
    }
    private void Start()
    {
        UnitSelectionSystem.Instance.OnSelectedUnit += UnitOnUnitSelected_OnUnitSelected;
        UpdateVisual();
    }
    void UpdateVisual()
    {
        selectionRenderer.enabled = unit.IsSelected();
    }
    void UnitOnUnitSelected_OnUnitSelected()
    {
        UpdateVisual();
    }
    private void OnDestroy()
    {
        UnitSelectionSystem.Instance.OnSelectedUnit -= UnitOnUnitSelected_OnUnitSelected;
    }
}
