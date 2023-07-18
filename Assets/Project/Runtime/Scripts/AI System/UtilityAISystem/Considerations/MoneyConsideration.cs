using RPGSandBox.UtilityAISystem.UtilityAISO;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIConsiderations
{
    [CreateAssetMenu(fileName = "MoneyConsideration", menuName = "UtilityAISystem/Considerations/MoneyConsideration")]
    public class MoneyConsideration : ConsiderationDataSO
    {
        public override void CalculateConsiderationScore()
        {
            SetScore(0.9f);
        }
    }
}
