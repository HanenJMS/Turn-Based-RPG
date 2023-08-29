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
        private void Update()
        {
            if (!isRunning) return;
            if (!CanExecute(actionTarget)) return;
            if (!unit.Target().CheckingRange()) return;
            if (unit.Target().CheckingRange())
            {
                ExecuteBaseAction();
            }
            unit.Execute(null);
        }
        private void OnEnable()
        {
            Initialize();
        }
        public virtual void Awake()
        {
            Initialize();
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
            unit.Execute(this);
        }
        public abstract bool CanExecute(object target);
        public virtual void Cancel()
        {
            isRunning = false;
            unit.Target().Targeting(null, 0f);
        }
        public abstract void ExecuteBaseAction();
        public virtual void Initialize()
        {
            unit = GetComponent<IAmAUnit>();
            isRunning = false;
        }
    }
}

