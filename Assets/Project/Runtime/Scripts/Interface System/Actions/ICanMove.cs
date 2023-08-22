using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface ICanMove : IAmAnAction
    {
        void Moving(Vector3 destination);
        bool HasPath();
    }
}