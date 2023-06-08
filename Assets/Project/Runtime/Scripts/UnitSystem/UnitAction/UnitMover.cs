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
    }
}

