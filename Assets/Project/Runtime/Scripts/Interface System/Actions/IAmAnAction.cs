using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnAction
    {
        void Cancel();
        void Execute(object target);
        bool CanExecute(object target);
        string ActionName();
    }
}

