using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnAction
    {
        void Cancel();
        void Executing(IAmAnAction action);
        List<IAmAnAction> MyActionsList();
        bool IsCurrentActionRunning();
        string CurrentActionName();
    }
}

