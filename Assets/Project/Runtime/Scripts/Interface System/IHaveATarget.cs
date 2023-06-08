namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveATarget
    {
        void Targeting(IAmInteractable target, float range);
        bool CheckingRange();
    }
}

