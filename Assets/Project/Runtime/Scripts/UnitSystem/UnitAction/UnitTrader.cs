using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitTrader : UnitActionBase, ICanTrade
    {
        IAmAnInventory inventory;
        IAmAUnit target;
        IAmAMerchant merchant;
        public void Trade(IAmAUnit target)
        {
            Debug.Log($"{this.gameObject.name} is trading with {target.InteractableName()}");
            merchant.Sucker(target);
        }

        public override void Cancel()
        {
            base.Cancel();
            target.Execute(null);
            target = null;
        }

        public override bool CanExecute(object target)
        {
            if (inventory == null)
            {
                return false;
            }

            return target is IAmAUnit;
        }

        public override void Execute(object target)
        {
            base.Execute(target);
            SetTarget(target);
            unit.Mover().Moving(this.target.MyPosition());
        }


        public override void SetTarget(object target)
        {

            this.target = target as IAmAUnit;
            unit.Targeter().Targeting(this.target, 1f);
        }

        public override void ExecuteBaseAction()
        {
            Trade(target);
        }

        public override void Initialize()
        {
            base.Initialize();
            inventory = GetComponent<IAmAnInventory>();
            actionName = "Trade";
        }
    }
}

