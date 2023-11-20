using RPGSandBox.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameAISystem.GoalSystem
{
    public abstract class Goal : ScriptableObject
    {
        [SerializeField] bool isComplete = false;

        [SerializeField] ItemType target = null;

        [SerializeField] int Qty = 0;



    }
}

