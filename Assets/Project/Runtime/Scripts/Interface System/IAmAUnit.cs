using RPGSandBox.GameUtilities.GridCore;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit : IAmInteractable
    {
        bool IsSelected();
        void Move(Vector3 destination);
        void Speak(string message);
    }
}
