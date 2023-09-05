using RPGSandBox.InterfaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.CraftingSystem
{
    public class CraftingStation : MonoBehaviour, IAmACraftingStation
    {
        [SerializeField] List<CraftingRecipe> availableRecipes = new List<CraftingRecipe>();
        [SerializeField] string interactableName;
        int time = 4, currentTimer = 0;
        public bool Craft(IAmAUnit crafter, IHaveACraftingRecipe recipe)
        {
            foreach (CraftingRecipe recipes in availableRecipes)
            {
                recipe = recipes;
                if (!CanBeCrafted(crafter, recipe)) continue;
                CraftingExchange(crafter, recipe);
                GameObject craftedItem = Instantiate(recipe.Product().item.prefab, this.transform.position, Quaternion.identity);
                if (!craftedItem.TryGetComponent(out IAmAnItem item)) continue;
                //item.SetOwner(crafter);
                currentTimer = time;
                StartCoroutine(WaitAFewSeconds(crafter, item));

            }
            return true;
        }


        private IEnumerator WaitAFewSeconds(IAmAUnit crafter, IAmAnItem item)
        {

            if (currentTimer > 0)
            {
                currentTimer--;
                yield return new WaitForSeconds(1);
            }
            if (item != null)
            {
                //crafter.Inventory().Storing(item);
            }
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
                item.GetItemWorldInventorySlot().AddToItemQuantity(qty);
                //if (!crafter.Inventory().Checking(item)) return false;
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
                item.GetItemWorldInventorySlot().AddToItemQuantity(qty);
                //crafter.Inventory().Removing(item);
            }
        }
        public bool CanInteract(IAmInteractable interact)
        {
            return false;
        }

        public Vector3 GetWorldPosition()
        {
            return this.transform.position;
        }
        public string DescriptionHeader()
        {
            return this.gameObject.name;
        }
        public string DescriptionContent()
        {
            return this.GetType().ToString();
        }

        public string InteractableName()
        {
            return interactableName;
        }
    }
}

