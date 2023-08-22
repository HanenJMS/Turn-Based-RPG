using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        void Trade(IAmAUnit target);
        void Move(Vector3 destination);
        void Speak(string message, bool priority);
        void Craft(IAmACraftingStation station);
        void Gather(IAmAnItem item);
        void Store(IAmAnItem item);
        void Remove(IAmAnItem item, int qty);
        bool Check(IAmAnItem item, int qty);
        void Execute(IAmAnAction action);
        void Target(object target, float range);
        bool IsTargeting(object target);
        bool CheckIsInRange();
        bool HasPath();
        IHaveAnInventory Inventory();
        List<IAmAnAction> ActionList();
    }
}
