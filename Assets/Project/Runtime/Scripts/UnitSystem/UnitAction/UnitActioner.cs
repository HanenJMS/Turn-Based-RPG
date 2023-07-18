using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitActioner : MonoBehaviour, IHaveAnAction
    {
        IAmAnAction currentAction = null;
        IHaveATarget targeter;
        public void Executing(IAmAnAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
        //private void TryToExecute()
        //{
        //    if (target == null) return;
        //    if (!unit.CheckIsRange())
        //    {
        //        unit.Move(target.MyPosition());
        //    }
        //    unit.Gather(target);
        //}
    }
}

