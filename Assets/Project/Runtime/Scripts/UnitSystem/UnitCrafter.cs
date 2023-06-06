using RPGSandBox.InterfaceSystem;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace RPGSandBox.UnitSystem
{
    public class UnitCrafter : MonoBehaviour, ICanCraft
    {
        IAmACraftingStation targetStation = null;
        IHaveACraftingRecipe recipe;
        IAmAUnit unit;
        bool withinRange = false;
        private void Awake()
        {
            unit = GetComponent<IAmAUnit>();
        }
        private void Update()
        {
            TryToCraft();
        }
        public void Crafting(IAmAUnit craftingUnit, IAmACraftingStation station)
        {


            withinRange = IsInRange(station);
            if (unit == null || unit != craftingUnit) unit = craftingUnit;
            if (!withinRange)
            {
                targetStation = station;
                craftingUnit.Execute(this);
                return;
            }
            if (!station.Craft(unit, recipe))
            {
                unit.Speak("I can't Craft that", true);
                return;
            }
            unit.Speak("Crafting", true);
            targetStation = null;
        }

        private void TryToCraft()
        {
            if (targetStation == null) return;
            if (!withinRange)
            {
                unit.Move(targetStation.MyPosition());
            }
            unit.Craft(targetStation);
        }
        private bool IsInRange(IAmACraftingStation station)
        {
            float pickUpDistance = 2f;
            return Vector3.Distance(station.MyPosition(), unit.MyPosition()) < pickUpDistance;
        }

        public void Cancel()
        {
            targetStation = null;
            withinRange = false;
        }
    }
}
