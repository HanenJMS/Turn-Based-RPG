using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitGatherer : MonoBehaviour, ICanGather
    {
        IAmAnItem itemTarget = null;
        IAmAUnit unit = null;
        bool withinRange = false;
        private void Update()
        {
            TryToGather();
        }
        private void Start()
        {
            unit = GetComponent<IAmAUnit>();
        }
        public void Gathering(IAmAUnit gatheringUnit, IAmAnItem item)
        {
            withinRange = IsInRange(item);
            if (unit == null || unit != gatheringUnit) unit = gatheringUnit;
            if (!withinRange)
            {
                itemTarget = item;
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
            itemTarget = null;
        }
        private void TryToGather()
        {
            if (itemTarget == null) return;
            if (!withinRange)
            {
                unit.Move(itemTarget.MyPosition());
            }
            unit.Gather(itemTarget);
        }
        private bool IsInRange(IAmAnItem item)
        {
            float pickUpDistance = 1f;
            return Vector3.Distance(item.MyPosition(), unit.MyPosition()) < pickUpDistance;
        }
    }
}

