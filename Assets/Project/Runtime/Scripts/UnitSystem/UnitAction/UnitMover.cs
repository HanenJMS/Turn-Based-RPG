using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitMover : MonoBehaviour, ICanMove
    {
        NavMeshAgent agent;
        IAmAUnit unit;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            unit = GetComponent<IAmAUnit>();
        }
        public void Moving(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
        public void SetToMoving(Vector3 destination)
        {
            unit.Execute(this);
            Moving(destination);
        }
        public void Cancel()
        {
            agent.SetDestination(this.transform.position);
        }

        public void Execute(object target)
        {
            Vector3 destination = (Vector3)target;
            SetToMoving(destination);
        }

        public bool CanExecute(object target)
        {
            return target is Vector3;
        }

        public string ActionName()
        {
            return "Move To";
        }
        public bool HasPath()
        {
            return agent.hasPath;
        }
    }
}

