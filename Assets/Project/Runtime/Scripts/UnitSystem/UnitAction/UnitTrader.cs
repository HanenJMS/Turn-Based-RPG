using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitTrader : UnitActionBase, ICanTrade, IAmATrader
    {
        IAmAnInventory inventory;
        IAmAUnit targetWorld;
        IAmATrader targetTrader;
        IHaveAMarket market;
        public void Trade(IAmATrader target)
        {
            Debug.Log($"{this.gameObject.name} is trading with {targetWorld.InteractableName()}");
        }
        public IHaveAMarket Market()
        {
            return market;
        }
        public override void Cancel()
        {
            base.Cancel();
            targetWorld.Execute(null);
            targetWorld = null;
            targetTrader = null;
        }

        public override bool CanExecute(object target)
        {
            if (market == null)
            {
                return false;
            }
            return target is IAmAUnit;
        }

        public override void Execute(object target)
        {
            base.Execute(target);
            SetTarget(target);
            unit.Move().Moving(this.targetWorld.GetWorldPosition());
        }


        public override void SetTarget(object target)
        {
            this.targetWorld = target as IAmAUnit;
            this.targetTrader = targetWorld.Trader();
            unit.Target().Targeting(this.targetTrader, 1f);
        }

        public override void ExecuteBaseAction()
        {
            Trade(targetTrader);
        }

        public override void Initialize()
        {
            base.Initialize();
            market = GetComponent<IHaveAMarket>();
            actionName = "Trade";
        }
    }
}

