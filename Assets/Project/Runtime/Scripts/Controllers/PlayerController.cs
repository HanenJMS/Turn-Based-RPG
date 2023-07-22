using RPGSandBox.InterfaceSystem;
using RPGSandBox.UnitSystem;
using UnityEngine;
namespace RPGSandBox.Controller
{
    public class PlayerController : PlayerControllerSystem
    {
        public static PlayerController instance { get; private set; }
        Vector3 mousePositionStart;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
            instance = this;
        }
        public override void HandleLeftMouseDownStart()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleLeftMouseDownMid()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleLeftMouseDownEnd()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleRightMouseDownStart()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleRightMouseDownMid()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleRightMouseDownEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}

