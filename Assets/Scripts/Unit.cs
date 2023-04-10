using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Vector3 targetPosition;
    float moveSpeed = 5.5f;
    float stoppingDistance = 1f;
    float rotationSpeed = 50f;
    [SerializeField] Animator animator;
    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Update()
    {

        if (!IsWithinDistance())
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
    bool IsWithinDistance()
    {
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
    public void Move(Vector3 destination)
    {
        targetPosition = destination;
    }
}
