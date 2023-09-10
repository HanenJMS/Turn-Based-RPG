using RPGSandBox.TradingSystem;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveAMarket
    {
        Demand GetDemandList();
        Supply GetSupplyList();
    }
}
