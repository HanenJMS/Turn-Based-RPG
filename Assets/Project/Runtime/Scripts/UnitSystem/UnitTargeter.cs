using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitTargeter : MonoBehaviour, IHaveATarget
    {
        IAmInteractable currentTarget;
        float range;

        public void Targeting(IAmInteractable target, float range)
        {
            currentTarget = target;
            this.range = range;
        }
        public bool IsCurrentlyTargeting(IAmInteractable target)
        {
            if (currentTarget == null)
            {
                return false;
            }
            return currentTarget == target;
        }
        public bool CheckingRange()
        {
            bool isRanged = false;
            if (currentTarget != null)
            {
                isRanged = Vector3.Distance(this.transform.position, currentTarget.MyPosition()) < range;
            }
            return isRanged;
        }
    }
}

