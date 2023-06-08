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
            TryToGather();
        }
        private void Start()
        {
            unit = GetComponent<IAmAUnit>();
        }
        public void Gathering(IAmAnItem item)
        {
            unit.Target(item, 2f);
            if (!unit.CheckIsInRange())
            {
                target = item;
                unit.Execute(this);
                return;
            }
            if (!item.ItemHasAnOwner())
            {
                unit.Store(item);
                unit.Speak("I grabbed something.", true);
            }
            else if (item.ItemHasAnOwner())
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

