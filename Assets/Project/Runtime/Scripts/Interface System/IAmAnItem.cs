using System.Runtime.CompilerServices;

namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnItem : IAmInteractable
    {
        IAmAnItem PickUpItem();
    }
}

