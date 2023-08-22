using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitActioner : MonoBehaviour, IHaveAnAction
    {
        IAmAnAction currentAction = null;
        List<IAmAnAction> myActionsList;
        Queue<IAmAnAction> queuedActions = new Queue<IAmAnAction>();
        private void Initialize()
        {
            myActionsList = new List<IAmAnAction>(gameObject.GetComponents<IAmAnAction>());
        }

        public void Executing(IAmAnAction action)
        {
            if (currentAction == action) return;
            if (currentAction is not null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }

        public List<IAmAnAction> MyActionsList()
        {
            Initialize();
            return myActionsList;
        }
    }
}

