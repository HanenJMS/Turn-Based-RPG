using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        ICanTrade Trade();
        ICanMove Move();
        ICanCraft Craft();
        ICanGather Gather();
        IAmAnInventory Inventory();
        IAmATrader Trader();
        IHaveATarget Target();
        void Speak(string message, bool priority);
        void Execute(IAmAnAction action);
        List<IAmAnAction> ActionList();
    }
}
