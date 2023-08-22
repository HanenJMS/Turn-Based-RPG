namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnAction
    {
        
        void Execute(object target);
        bool CanExecute(object target);
        void SetTarget(object target);
        void Cancel();
        string ActionName();
        void PlayerExecute(object target);
    }
}

