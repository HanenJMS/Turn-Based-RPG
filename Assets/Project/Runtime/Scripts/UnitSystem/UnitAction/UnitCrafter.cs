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
            TryToCraft();
        }
        public void Crafting(IAmACraftingStation station)
        {

            unit.Target(station, 2f);
            if (!unit.CheckIsInRange())
            {
                target = station;
                unit.Execute(this);
                return;
            }
            if (!station.Craft(unit, recipe))
            {
                unit.Speak("I can't Craft that", true);
                return;
            }
            unit.Speak("Crafting", true);
            target = null;
        }

        private void TryToCraft()
        {
            if (target == null) return;
            if (!unit.CheckIsInRange())
            {
                unit.Move(target.MyPosition());
            }
            unit.Craft(target);
        }

        public void Cancel()
        {
            target = null;
        }

        public void Execute(object interactable)
        {
            if (interactable == null) return;
            if ((IAmACraftingStation)interactable == null) return;
            Crafting((IAmACraftingStation) interactable);
        }

        public bool CanExecute(object target)
        {
            return target is IAmACraftingStation;


        }

        public string ActionName()
        {
            return "Use machine";
        }
    }
}
