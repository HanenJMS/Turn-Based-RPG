using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.InteractableSystem
{
    public class InteractableSelectionSystem : PlayerControllerSystem
    {
        public override void HandleLeftMouseDownEnd()
        {
        }

        public override void HandleLeftMouseDownMid()
        {
        }

        public override void HandleLeftMouseDownStart()
        {
            RaycastHit hit = MouseWorld.GetMouseRayCastHit();
            if(hit.transform.TryGetComponent(out IAmInteractable interactable))
            {

            }
        }

        public override void HandleRightMouseDownEnd()
        {
        }

        public override void HandleRightMouseDownMid()
        {
        }

        public override void HandleRightMouseDownStart()
        {
        }
    }
}

