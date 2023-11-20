using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public abstract class UnitActionBase : MonoBehaviour, IAmAnAction
    {
        public object actionTarget;
        public IAmAUnit unit;
        public string actionName = "";
        public bool isRunning = false;
        public float minimumDistance = 0.5f;
        private void Update()
        {
            if (!isRunning) return;
            if (!CanExecute(actionTarget)) return;
            if (!unit.Target().CheckingIsInRange()) return;
            if (unit.Target().CheckingIsInRange())
            {
                ExecuteBaseAction();
            }
            unit.Actioner().Cancel();
        }
        private void OnEnable()
        {
            Initialize();
        }
        public virtual void Awake()
        {
            Initialize();
        }
        public bool IsExecuting()
        {
            return isRunning;
        }
        public string ActionName()
        {
            return actionName;
        }
        public abstract void SetTarget(object target);
        public virtual void Execute(object target)
        {
            if (!CanExecute(target)) return;
            isRunning = true;
            unit.Actioner().Executing(this);
        }
        public abstract bool CanExecute(object target);
        public virtual void Cancel()
        {
            isRunning = false;
            unit.Target().SetTarget(null, minimumDistance);
        }
        public abstract void ExecuteBaseAction();
        public virtual void Initialize()
        {
            unit = GetComponent<IAmAUnit>();
            isRunning = false;
        }
    }
}

