using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitCrafter : MonoBehaviour, ICanCraft
    {
        public void Crafting(IAmAUnit unit, IAmACraftingStation station)
        {
            if(!station.Craft(unit))
            {
                unit.Speak("I can't Craft that", false);
                return;
            }
            unit.Speak("Crafting", true);
        }
    }
}
