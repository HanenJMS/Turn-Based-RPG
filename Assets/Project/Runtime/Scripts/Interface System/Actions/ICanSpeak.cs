namespace RPGSandBox.InterfaceSystem
{
    public interface ICanSpeak : IAmAnAction
    {
        void Saying(string message, bool priority);
    }
}
