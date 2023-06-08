using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        void Move(Vector3 destination);
        void Speak(string message, bool priority);
        void Craft(IAmACraftingStation station);
        void Gather(IAmAnItem item);
        void Store(IAmAnItem item);
        void Remove(IAmAnItem item, int qty);
        bool Check(IAmAnItem item, int qty);
        void Execute(IAmAnAction action);
        void Target(IAmInteractable target, float range);
        bool CheckIsInRange();
        void SetToMove(Vector3 destination);
    }
}
