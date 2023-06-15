using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitGatherer : MonoBehaviour, ICanGather
    {
        IAmAnItem target = null;
        IAmAUnit unit = null;
        private void Update()
        {
            if (target == null) return;
            TryToGather();
        }
        private void Start()
        {
            unit = GetComponent<IAmAUnit>();
        }
        public void Gathering(IAmAnItem item)
        {
            if (item == null) return;
            unit.Target(item, 2f);
            if (!unit.CheckIsInRange())
            {
                target = item;
                unit.Execute(this);
                return;
            }
            if (item.OwnedBy(unit) || !item.HasAnOwner())
            {
                unit.Store(item);
                unit.Speak("I grabbed something.", true);
            }
            else if (!item.OwnedBy(unit) || item.HasAnOwner())
            {
                unit.Speak("Item was already picked up it seems.", true);
            }
            target = null;
        }
        private void TryToGather()
        {
            if (target == null) return;
            if (!unit.CheckIsInRange())
            {
                unit.Move(target.MyPosition());
            }
            unit.Gather(target);
        }

        public void Cancel()
        {
            target = null;
        }
    }
}

