using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitCrafter : UnitActionBase, ICanCraft
    {
        IAmACraftingStation target = null;
        IHaveACraftingRecipe recipe = null;
        private void Update()
        {
            if (!CanExecute(target)) return;
            if (!unit.Target().CheckingRange()) return;
            if (unit.Target().CheckingRange())
            {
                ExecuteBaseAction();
            }
            unit.Execute(null);
        }
        public void Crafting(IAmACraftingStation station)
        {
            target.Craft(unit, recipe);
        }

        public override void Execute(object target)
        {
            base.Execute(target);
            SetTarget(target);
            unit.Move().Moving(this.target.MyPosition());
        }

        public override bool CanExecute(object target)
        {
            if (target is null) return false;
            if (!(target is IAmACraftingStation)) return false;
            return true;
        }
        public override void Cancel()
        {
            base.Cancel();
            target = null;
        }
        

        public override void SetTarget(object target)
        {
            this.target = target as IAmACraftingStation;
            actionTarget = target;
            unit.Target().Targeting(this.target, 2f);
        }


        public override void ExecuteBaseAction()
        {
            Crafting(target);
        }

        public override void Initialize()
        {
            base.Initialize();
            actionName = "Use";
        }
    }
}
