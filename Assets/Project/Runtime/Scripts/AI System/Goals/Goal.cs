using RPGSandBox.InteractableSystem;
using UnityEngine;
namespace RPGSandBox.GameAISystem.GoalSystem
{
    public abstract class Goal : ScriptableObject
    {
        [SerializeField] bool isComplete = false;

        [SerializeField] ItemData target = null;

        [SerializeField] int Qty = 0;



    }
}

