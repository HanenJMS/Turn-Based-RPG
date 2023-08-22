using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitGatherer : UnitActionBase, ICanGather
    {
        IAmAnItem target = null;
        public void Gathering(IAmAnItem item)
        {
            unit.Inventory().Storing(item);
        }

        public override void Cancel()
        {
            base.Cancel();
            target = null;
        }

        public override bool CanExecute(object target)
        {
            if (target == null) return false;
            if (!(target is IAmAnItem)) return false;
            return true;
        }

        public override void SetTarget(object target)
        {
            this.target = target as IAmAnItem;
            actionTarget = target;
            unit.Targeter().Targeting(this.target, 1f);
        }

        public override void ExecuteBaseAction()
        {
            unit.Gatherer().Gathering(target);
        }

        public override void Execute(object target)
        {
            base.Execute(target);
            SetTarget(target);
            unit.Mover().Moving(this.target.MyPosition());
        }

        public override void Initialize()
        {
            base.Initialize();
            actionName = "Gather";
        }
    }
}

