using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitMover : MonoBehaviour, ICanMove
    {
        NavMeshAgent agent;
        private void Awake()
        {
            agent = GetComponentInParent<NavMeshAgent>();
        }
        public void MoveToDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
    }
}

