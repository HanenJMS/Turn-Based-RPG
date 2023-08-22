using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.UnitSystem
{
    public class UnitTargeter : MonoBehaviour, IHaveATarget
    {
        IAmInteractable targetDestination = null;
        Vector3 worldDestination;
        float range;

        public void Targeting(object target, float range)
        {
            if(target is IAmInteractable)
            {
                targetDestination = target as IAmInteractable;
                worldDestination = targetDestination.MyPosition();
            }
            if(target is Vector3)
            {
                worldDestination = (Vector3)target;
            }
            if(target is null)
            {
                worldDestination = this.transform.position;
            }
            this.range = range;
        }
        public bool IsCurrentlyTargeting(object target)
        {
            if (targetDestination == null)
            {
                return false;
            }
            return targetDestination == target;
        }
        public bool CheckingRange()
        {
            bool isRanged = false;
            if (worldDestination != null)
            {
                isRanged = Vector3.Distance(this.transform.position, worldDestination) <= range;
            }
            return isRanged;
        }
    }
}

