using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmATrader
    {
        IHaveAMarket Market();
        public IAmAnInventory GetInventory();
    }
}

