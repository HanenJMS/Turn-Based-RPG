using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitMover : MonoBehaviour
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

