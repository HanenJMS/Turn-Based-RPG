using UnityEngine;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmACraftingStation
    {
        bool Craft(IAmAUnit crafter);
    }
}

