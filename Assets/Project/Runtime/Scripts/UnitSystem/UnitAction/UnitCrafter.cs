using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitCrafter : MonoBehaviour, ICanCraft
    {

        IAmAUnit unit = null;
        IAmACraftingStation target = null;
        IHaveACraftingRecipe recipe = null;
        private void Awake()
        {
            unit = GetComponent<IAmAUnit>();
        }
        private void Update()
        {
            if (!CanExecute(target)) return;
            if (!unit.CheckIsInRange()) return;
            if (unit.CheckIsInRange())
            {
                unit.Craft(target);
            }
            unit.Execute(null);
        }
        public void Crafting(IAmACraftingStation station)
        {
            target.Craft(unit, recipe);
        }

        public void Execute(object interactable)
        {
            if (!CanExecute(interactable)) return;
            target = interactable as IAmACraftingStation;
            unit.Target(target, 2f);
            unit.Execute(this);
            unit.Move(target.MyPosition());
        }

        public bool CanExecute(object target)
        {
            if (target is null) return false;
            if (!(target is IAmACraftingStation)) return false;
            return true;
        }
        public void Cancel()
        {
            target = null;
        }
        public string ActionName()
        {
            return "Use machine";
        }
    }
}
