using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface ICanMove
    {
        void MoveToDestination(Vector3 destination);
    }
}