using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        void Move(Vector3 destination);
        void Speak(string message, bool priority);
        void Gather(IAmAnItem item);
        void Store(IAmAnItem item);
    }
}
