using RPGSandBox.InterfaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.CraftingSystem
{
    public class CraftingStation : MonoBehaviour, IAmACraftingStation
    {
        [SerializeField] List<CraftingRecipe> availableRecipes = new List<CraftingRecipe>();
        public bool Craft(IAmAUnit crafter)
        {
            IAmAnItem item = availableRecipes[0].craftingIngredient[0].item.prefab.GetComponent<IAmAnItem>();
            int quantity = availableRecipes[0].craftingIngredient[0].qty;

            if(!crafter.Check(item, quantity))
            {
                return false;
            }
            Instantiate(availableRecipes[0].craftedProduct.item.prefab, this.transform.position, Quaternion.identity);
            return true;
        }
    }
}

