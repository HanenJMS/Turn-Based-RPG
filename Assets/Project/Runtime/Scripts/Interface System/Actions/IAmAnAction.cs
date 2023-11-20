namespace RPGSandBox.InterfaceSystem
{
    public interface IAmAnAction
    {
        bool IsExecuting();
        void Execute(object target);
        bool CanExecute(object target);
        void SetTarget(object target);
        void Cancel();
        string ActionName();
    }
}

