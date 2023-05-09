using UnityEngine;
using UnityEngine.AI;


public class UnitMover : MonoBehaviour
{
    Vector3 destination;
    float approachingDistance;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
    private void Update()
    {
        if (agent == null) return;
        if(GetIsInDistance())
        agent.SetDestination(destination);
    }
    bool GetIsInDistance()
    {
        return Vector3.Distance(this.transform.position, destination) < approachingDistance;
    }
}
