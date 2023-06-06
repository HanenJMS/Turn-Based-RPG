using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.UnitSystem
{
    public class UnitActions : MonoBehaviour, IHaveAnAction
    {
        IAmAnAction currentAction = null;
        public void Executing(IAmAnAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }
}
