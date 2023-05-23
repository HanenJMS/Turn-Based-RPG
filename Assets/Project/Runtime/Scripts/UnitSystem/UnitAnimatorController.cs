using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class UnitAnimatorController : MonoBehaviour
{
    [SerializeField] Animator unitAnimator;
    NavMeshAgent agent;
    private void Awake()
    {
        unitAnimator = GetComponentInChildren<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private void Update()
    {
        HandleIdleWalkRunAnimation();
    }

    private void HandleIdleWalkRunAnimation()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        unitAnimator.SetFloat("forwardSpeed", speed);
    }
}
