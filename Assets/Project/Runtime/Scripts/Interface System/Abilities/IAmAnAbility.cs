using JetBrains.Annotations;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnAbility
    {
        void UsingOn(IAmInteractable target);
    }
}
