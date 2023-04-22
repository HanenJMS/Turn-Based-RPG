using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RTSController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform = null;
    Vector3 startPosition;
    private List<Unit> selectedUnitList;
    private void Awake()
    {
        selectionAreaTransform.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = MouseWorld.GetMousePosition();

            DeselectAllUnits();
        }
        if (Input.GetMouseButton(0))
        {
            // Left Mouse Button Held Down
            float width = (MouseWorld.GetMousePosition().x - startPosition.x);
            float length = (MouseWorld.GetMousePosition().z - startPosition.z);
            Vector3 scale = new Vector3(width, 1, length);
            selectionAreaTransform.position = new Vector3(width/2+startPosition.x, 1, length/2 + startPosition.z);
            selectionAreaTransform.localScale = scale;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            selectionAreaTransform.gameObject.SetActive(false);
            
        }
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
        }
    }
    private void CalculateSelectionLowerLeftUpperRight(out Vector3 lowerLeft, out Vector3 upperRight)
    {
        Vector3 currentMousePosition = MouseWorld.GetMousePosition();
        lowerLeft = new Vector3(
            Mathf.Min(startPosition.x, currentMousePosition.x),
            0.2f,
            Mathf.Min(startPosition.z, currentMousePosition.z)
        );
        upperRight = new Vector3(
            Mathf.Max(startPosition.x, currentMousePosition.x),
            0.2f,
            Mathf.Max(startPosition.z, currentMousePosition.z)
        );
    }
    private void DeselectAllUnits()
    {
        foreach (Unit unit in selectedUnitList)
        {
            unit.SetIsSelected(false);
        }

        selectedUnitList.Clear();
    }
}
