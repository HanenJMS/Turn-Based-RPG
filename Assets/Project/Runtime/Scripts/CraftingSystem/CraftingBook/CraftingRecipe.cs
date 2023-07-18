using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.CraftingSystem
{

    [CreateAssetMenu(fileName = "Crafting Recipe", menuName = "Crafting/Crafting Recipe")]
    public class CraftingRecipe : ScriptableObject, IHaveACraftingRecipe
    {
        public List<RecipeReference> craftingMaterials;
        public RecipeReference craftingProduct;

        public List<RecipeReference> NeededMaterials()
        {
            return craftingMaterials;
        }
        public RecipeReference Product()
        {
            return craftingProduct;
        }
    }

}

