using RPGSandBox.InventorySystem.Item;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.CraftingSystem
{

    [CreateAssetMenu(fileName = "Crafting Recipe", menuName = "Crafting/Crafting Recipe")]
    public class CraftingRecipe : ScriptableObject
    {
        public List<RecipeReference> item;
        public RecipeReference outputItem;
    }

}

