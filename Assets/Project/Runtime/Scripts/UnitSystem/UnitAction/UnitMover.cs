using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.AI;

namespace RPGSandBox.UnitSystem
{
    public class UnitMover : UnitActionBase, ICanMove
    {
        NavMeshAgent agent;
        Vector3 target;
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
            unit.Target().SetTarget(target, 0.5f);
        }
        public override bool CanExecute(object target)
        {
            return target is Vector3;
        }
        public override void Execute(object target)
        {
            base.Execute(target);
            SetTarget(target);
            this.actionTarget = (Vector3)target;
            unit.Move().Moving((Vector3)this.actionTarget);
            Debug.Log("I Execute movement");
        }
        public override void Cancel()
        {
            base.Cancel();
            Debug.Log("I cancel movement");
            target = this.transform.position;
            agent.SetDestination(target);
        }
        public override void ExecuteBaseAction()
        {
            Debug.Log("I Execute movement base action");
        }
        public override void Initialize()
        {
            base.Initialize();
            actionName = "Move To";
        }
    }
}

