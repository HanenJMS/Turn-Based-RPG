using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitGatherer : MonoBehaviour, ICanGather
    {
        IAmAnItem target = null;
        IAmAUnit unit = null;

        private void Start()
        {
            unit = GetComponent<IAmAUnit>();
        }
        private void Update()
        {
            if (!CanExecute(target)) return;
            if (!unit.CheckIsInRange()) return;
            if (unit.CheckIsInRange())
            {
                unit.Gather(target);
            }
            unit.Execute(null);
        }
        public void Gathering(IAmAnItem item)
        {
            unit.Store(item);
        }

        public void Cancel()
        {
            target = null;
        }

        public void Execute(object interactable)
        {
            if (!CanExecute(interactable)) return;
            target = interactable as IAmAnItem;
            unit.Target(target, 1f);
            unit.Execute(this);
            unit.Move(target.MyPosition());
        }

        public bool CanExecute(object target)
        {
            if (target == null) return false;
            if (!(target is IAmAnItem)) return false;
            return true;
        }

        public string ActionName()
        {
            return "Gather";
        }
    }
}

