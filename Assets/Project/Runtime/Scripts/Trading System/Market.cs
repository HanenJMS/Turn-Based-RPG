using Codice.CM.SEIDInfo;
using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using UnityEngine;

namespace RPGSandBox.TradingSystem
{
    public class Market : MonoBehaviour, IHaveAMarket
    {
        Demand demandList = new();
        Supply supplyList = new();

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
