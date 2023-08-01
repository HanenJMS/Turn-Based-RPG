using RPGSandBox.CraftingSystem;
using System.Collections.Generic;

namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveACraftingRecipe
    {
        List<RecipeReference> NeededMaterials();
        RecipeReference Product();
    }
}

