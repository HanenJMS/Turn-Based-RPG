namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveATarget
    {
        void SetTarget(object target, float range);
        bool CheckingIsInRange();
        bool IsCurrentlyTargeting(object target);
    }
}

