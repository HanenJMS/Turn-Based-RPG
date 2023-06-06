using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.CraftingSystem
{
    public class CraftingStation : MonoBehaviour, IAmACraftingStation
    {
        [SerializeField] List<CraftingRecipe> availableRecipes = new List<CraftingRecipe>();
        public bool Craft(IAmAUnit crafter, IHaveACraftingRecipe recipe)
        {
            if (recipe == null) recipe = availableRecipes[0];
            if (!CanBeCrafted(crafter, recipe)) return false;
            CraftingExchange(crafter, recipe);
            Instantiate(recipe.Product().item.prefab, this.transform.position, Quaternion.identity);
            return true;
        }



        private bool CanBeCrafted(IAmAUnit crafter, IHaveACraftingRecipe recipe)
        {
            List<RecipeReference> neededMaterials = recipe.NeededMaterials();
            if (neededMaterials == null) return true;
            if (neededMaterials.Count <= 0) return true;
            foreach (RecipeReference material in neededMaterials)
            {
                IAmAnItem item = material.item.prefab.GetComponent<IAmAnItem>();
                int qty = material.qty;
                if (!crafter.Check(item, qty)) return false;
            }
            return true;
        }
        void CraftingExchange(IAmAUnit crafter, IHaveACraftingRecipe recipe)
        {
            List<RecipeReference> neededMaterials = recipe.NeededMaterials();
            foreach (RecipeReference material in neededMaterials)
            {
                IAmAnItem item = material.item.prefab.GetComponent<IAmAnItem>();
                int qty = material.qty;
                crafter.Remove(item, qty);
            }
        }
        public void Interact(IAmInteractable interact)
        {
            
        }

        public Vector3 MyPosition()
        {
            return this.transform.position;
        }
    }
}

