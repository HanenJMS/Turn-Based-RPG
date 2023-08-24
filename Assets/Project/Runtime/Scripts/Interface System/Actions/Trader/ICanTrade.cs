namespace RPGSandBox.InterfaceSystem
{
    public interface ICanTrade : IAmAnAction
    {
        void Trade(IAmAUnit target);

    }
}

