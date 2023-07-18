using RPGSandBox.UtilityAISystem.UtilityAISO;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.Core
{
    public class UtilityAIConsiderationHandler : MonoBehaviour
    {
        [SerializeField] List<ActionDataSO> actionsForConsideration = new List<ActionDataSO>();
        List<float> actionScores = new List<float>();

    }
}
