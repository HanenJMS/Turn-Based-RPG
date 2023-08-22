using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitMover : UnitActionBase, ICanMove
    {
        NavMeshAgent agent;
        public override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
        }
        public void Moving(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
        public bool HasPath()
        {
            return agent.hasPath;
        }
        public override void SetTarget(object target)
        {
            actionTarget = target;
        }
        public override bool CanExecute(object target)
        {
            return target is Vector3;
        }
        public override void Execute(object target)
        {
            base.Execute(target);
            Vector3 destination = this.transform.position;
            if (target is Vector3)
            {
                destination = (Vector3)target;
            }
            unit.Move(destination);
        }
        public override void Cancel()
        {
            base.Cancel();
            agent.SetDestination(this.transform.position);
        }
        public override void ExecuteBaseAction()
        {
            unit.Execute(null);
        }
        public override void Initialize()
        {
            base.Initialize();
            actionName = "Move To";
        }
    }
}

