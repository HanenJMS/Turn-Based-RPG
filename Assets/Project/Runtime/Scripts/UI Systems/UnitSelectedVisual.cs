using RPGSandBox.InterfaceSystem;
using RPGSandBox.UnitSystem;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] IAmAUnit unit;
    [SerializeField] MeshRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        unit = GetComponentInParent<IAmAUnit>();
    }
    private void Start()
    {
        UnitSelectionSystem.Instance.OnSelectedUnit += UnitOnUnitSelected_OnUnitSelected;
        UpdateVisual();
    }
    void UpdateVisual()
    {
        renderer.enabled = unit.IsSelected();
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
