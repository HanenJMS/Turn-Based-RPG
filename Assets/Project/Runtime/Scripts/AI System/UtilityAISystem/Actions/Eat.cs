using RPGSandBox.UtilityAISystem.UtilityAISO;
using System;
using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIActions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAISystem/Actions/Eat")]
    public class Eat : ActionDataSO
    {
        public override IEnumerator GetActionCoroutine()
        {
            int counter = 5;
            Execute();
            while (IsRunning())
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log($"{this.Name} Action Completed");
        }
    }
}
