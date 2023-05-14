using RPGSandBox.UtilityAISystem.UtilityAISO;
using System.Collections;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIActions
{
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAISystem/Actions/Work")]
    public class Work : ActionDataSO
    {

        public override IEnumerator GetActionCoroutine()
        {
            int counter = 5;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log($"{this.Name} Action Completed");
        }
    }
}


