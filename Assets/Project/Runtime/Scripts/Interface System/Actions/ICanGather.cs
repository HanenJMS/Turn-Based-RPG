namespace RPGSandBox.InterfaceSystem
{
    public interface ICanGather : IAmAnAction
    {
        void Gathering(IAmAUnit gatheringUnit, IAmAnItem item);
    }
}

