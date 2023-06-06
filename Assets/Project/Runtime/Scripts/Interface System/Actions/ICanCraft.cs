namespace RPGSandBox.InterfaceSystem
{
    public interface ICanCraft : IAmAnAction
    {
        void Crafting(IAmAUnit unit, IAmACraftingStation station);
        
    }
}

