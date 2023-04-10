using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Vector3 targetPosition;
    float moveSpeed = 4f;
    float stoppingDistance = 1f;

    private void Update()
    {
        if(!IsWithinDistance())
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Move(new Vector3(4, 0, 4));
        }    
    }
    bool IsWithinDistance()
    {
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
    void Move(Vector3 destination)
    {
        targetPosition = destination;
    }
}
