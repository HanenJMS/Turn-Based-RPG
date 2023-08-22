using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        ICanTrade Trader();
        ICanMove Mover();
        ICanCraft Crafter();
        ICanGather Gatherer();
        IAmAnInventory Inventory();
        IHaveATarget Targeter();
        void Speak(string message, bool priority);
        void Execute(IAmAnAction action);
        List<IAmAnAction> ActionList();
    }
}
