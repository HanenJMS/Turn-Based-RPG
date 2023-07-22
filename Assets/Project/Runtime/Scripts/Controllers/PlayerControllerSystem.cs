using RPGSandBox.InterfaceSystem;
using UnityEngine;

public abstract class PlayerControllerSystem : MonoBehaviour
{
    IAmInteractable interactOnButtonDown,
                    interactOnButton,
                    interactOnButtonUp;

    private void Update()
    {
        HandleLeftClick();
        HandleRightClick();
    }
    void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftMouseDownStart();
        }
        if (Input.GetMouseButton(0))
        {
            HandleLeftMouseDownMid();
        }
        if (Input.GetMouseButtonUp(0))
        {
            HandleLeftMouseDownEnd();
        }
    }
    void HandleRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleRightMouseDownStart();
        }
        if (Input.GetMouseButton(1))
        {
            HandleRightMouseDownMid();
        }
        if (Input.GetMouseButtonUp(1))
        {
            HandleRightMouseDownEnd();
        }
    }
    public abstract void HandleLeftMouseDownStart();
    public abstract void HandleLeftMouseDownMid();
    public abstract void HandleLeftMouseDownEnd();
    public abstract void HandleRightMouseDownStart();
    public abstract void HandleRightMouseDownMid();
    public abstract void HandleRightMouseDownEnd();
}
