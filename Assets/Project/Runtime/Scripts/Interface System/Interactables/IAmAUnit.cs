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
        ICanGather Gatherer();
        IAmAnInventory Inventory();
        IAmATrader Trader();
        IHaveATarget Target();
        IHaveAnAction Actioner();
        void Speak(string message, bool priority);
        List<IAmAnAction> ActionList();
    }
}
