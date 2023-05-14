using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionSystem : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private List<Transform> selectedUnits = new List<Transform>();

    private void Update()
    {
        // Handle unit selection
        if (Input.GetMouseButtonDown(0))
        {

        }
        else if (Input.GetMouseButton(0))
        {
            
        }
    }



    private void DeselectUnit(Transform unit)
    {
        selectedUnits.Remove(unit);
        unit.GetComponent<Renderer>().material.color = Color.white;
    }





    private Vector3 MouseToWorldPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
