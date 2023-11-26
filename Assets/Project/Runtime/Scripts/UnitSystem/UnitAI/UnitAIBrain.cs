using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameAISystem
{
    public class UnitAIBrain : MonoBehaviour, IHaveABrain
    {
        IAmAUnit unit;
        private void Awake()
        {
            unit = GetComponent<IAmAUnit>();
        }

        [SerializeField] int goalAmount = 0;
        [SerializeField] string target;

        [SerializeField] Inventory worldInventory = new();
        [SerializeField] IAmAnAction currentAction;
        private void Update()
        {

            if (IsExecutingGoal()) return;
        }
        private void Start()
        {

        }
        private bool IsExecutingGoal()
        {
            if (goalAmount <= 0) return false;
            if (target == null) return false;
            if(currentAction != null)
            {
                if (currentAction.IsExecuting()) return false;
            }

            return true;
        }
    }
}

