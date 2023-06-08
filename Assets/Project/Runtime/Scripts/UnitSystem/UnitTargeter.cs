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

        public bool CheckingRange()
        {
            return Vector3.Distance(currentTarget.MyPosition(), this.transform.position) < range;
        }
    }
}

