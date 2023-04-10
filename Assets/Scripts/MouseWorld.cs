using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] LayerMask mousePlaneLayerMask;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mousePlaneLayerMask));
        transform.position = hit.point;
    }
}
