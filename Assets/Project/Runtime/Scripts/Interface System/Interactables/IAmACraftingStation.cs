namespace RPGSandBox.InterfaceSystem
{
    public interface IAmACraftingStation : IAmInteractable
    {
        bool Craft(IAmAUnit crafter, IHaveACraftingRecipe recipe);
    }
}

