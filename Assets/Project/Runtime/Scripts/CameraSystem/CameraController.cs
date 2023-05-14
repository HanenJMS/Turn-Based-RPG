using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineCamera;
    float moveSpeed = 10f;
    float rotationSpeed = 100f;
    float zoomAmount = 1f;
    const float MIN_FOLLOW_Y = 2f;
    const float MAX_FOLLOW_Y = 12f;
    Vector3 targetFollowOffset;
    CinemachineTransposer cineMachineTransposer;

    private void Start()
    {
        cineMachineTransposer = cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cineMachineTransposer.m_FollowOffset;
    }
    
    private void Update()
    {
        HandleCameraMovement();
        HandleCameraRotation();
        HandleCameraZoom();
    }

    private void HandleCameraZoom()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount;
        }
        float zoomSpeed = 5f;
        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y, MAX_FOLLOW_Y);
        cineMachineTransposer.m_FollowOffset = Vector3.Lerp(cineMachineTransposer.m_FollowOffset, targetFollowOffset, Time.unscaledDeltaTime * zoomSpeed);
    }

    private void HandleCameraRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = -1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = +1f;
        }
        transform.eulerAngles += rotationVector * Time.unscaledDeltaTime * rotationSpeed;
    }

    private void HandleCameraMovement()
    {
        Vector3 inputMoveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x = +1f;
        }

        Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
        transform.position += moveVector * moveSpeed * Time.unscaledDeltaTime;
    }
}
