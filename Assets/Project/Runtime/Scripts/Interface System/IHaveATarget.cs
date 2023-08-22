namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveATarget
    {
        void Targeting(object target, float range);
        bool CheckingRange();
        bool IsCurrentlyTargeting(object target);
    }
}

