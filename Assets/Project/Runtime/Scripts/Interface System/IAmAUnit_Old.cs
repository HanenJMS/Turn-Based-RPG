using RPGSandBox.GameUtilities.GridCore;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAUnit_Old : IAmInteractable
    {
        void MoveToDestination(Vector3 destination);












        GameObject gameObject { get; }
        IEnumerable<BaseAction> GetActionList();
        MoveAction GetMoveAction();
        GridPosition GetUnitGridPosition();
        bool IsSelected();
        void SetIsSelected(bool v);
    }
}
