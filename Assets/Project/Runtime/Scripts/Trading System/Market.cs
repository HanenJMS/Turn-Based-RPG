using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.TradingSystem
{
    public class Market : MonoBehaviour, IHaveAMarket
    {
        [SerializeField] Demand demandList = new();
        [SerializeField] Supply supplyList = new();

        public Demand GetDemandList()
        {
            return demandList;
        }
        public Supply GetSupplyList()
        {
            return supplyList;
        }
    }
}
