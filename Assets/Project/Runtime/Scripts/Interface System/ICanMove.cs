using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface ICanMove
    {
        void MovingTo(Vector3 destination);
    }
}