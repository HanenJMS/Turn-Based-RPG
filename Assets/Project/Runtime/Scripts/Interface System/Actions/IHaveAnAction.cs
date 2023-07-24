using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAnAction
    {
        void Executing(IAmAnAction action);
        List<IAmAnAction> MyActionsList();
    }
}

