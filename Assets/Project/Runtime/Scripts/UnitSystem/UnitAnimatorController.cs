using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitAnimatorController : MonoBehaviour
    {
        [SerializeField] Animator unitAnimator;
        NavMeshAgent agent;
        private void Awake()
        {
            unitAnimator = GetComponentInChildren<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            HandleIdleWalkRunAnimation();
        }

        private void HandleIdleWalkRunAnimation()
        {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            unitAnimator.SetFloat("forwardSpeed", speed);
        }
    }
}

