using RPGSandBox.UtilityAISystem.UtilityAISO;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIConsiderations
{
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAISystem/Considerations/HungerConsideration")]
    public class HungerConsideration : ConsiderationDataSO
    {
        public override void CalculateConsiderationScore()
        {
            SetScore(0.2f);
        }
    }
}
