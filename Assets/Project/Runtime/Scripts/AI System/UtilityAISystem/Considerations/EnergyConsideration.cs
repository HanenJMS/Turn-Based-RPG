using RPGSandBox.UtilityAISystem.UtilityAISO;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAIConsiderations
{
    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAISystem/Considerations/EnergyConsideration")]
    public class EnergyConsideration : ConsiderationDataSO
    {
        public override void CalculateConsiderationScore()
        {
            SetScore(0.5f);
        }
    }
}

