using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveMouseInteraction
    {
        void HandleLeftMouseDownStart()
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
        }
        void HandleLeftMouseDownMid()
        {
            if (Input.GetMouseButton(0))
            {

            }
        }
        void HandleLeftMouseDownEnd()
        {
            if (Input.GetMouseButtonUp(0))
            {

            }
        }
        void HandleRightMouseDownStart()
        {
            if (Input.GetMouseButtonDown(1))
            {

            }
        }
        void HandleRightMouseDownMid()
        {
            if (Input.GetMouseButton(1))
            {

            }
        }
        void HandleRightMouseDownEnd()
        {
            if (Input.GetMouseButtonUp(1))
            {

            }
        }
    }
}

