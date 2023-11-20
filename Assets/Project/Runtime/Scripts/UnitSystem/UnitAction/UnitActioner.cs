using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitActioner : MonoBehaviour, IHaveAnAction
    {
        const string defaultActionName = "NO ACTION";
        IAmAnAction currentAction = null;
        List<IAmAnAction> myActionsList;
        Queue<IAmAnAction> queuedActions = new Queue<IAmAnAction>();
        private void Initialize()
        {
            myActionsList = new List<IAmAnAction>(gameObject.GetComponents<IAmAnAction>());
        }
        public void Cancel()
        {
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = null;
        }
        public bool IsCurrentActionRunning()
        {
            if (currentAction == null) return false;
            return currentAction.IsExecuting();
        }
        public string CurrentActionName()   
        {
            if (currentAction == null) return defaultActionName;
            return currentAction.ActionName();
        }
        public void Executing(IAmAnAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
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

