using RPGSandBox.UtilityAISystem.UtilityAISO;
using System.Collections;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIActions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAISystem/Actions/Eat")]
    public class Eat : ActionDataSO
    {
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator GetActionCoroutine()
        {
            int counter = 5;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log($"{this.name} Action Completed");
        }
    }
}
