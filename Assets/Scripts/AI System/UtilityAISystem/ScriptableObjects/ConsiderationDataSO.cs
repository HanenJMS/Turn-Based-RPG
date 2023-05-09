using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAISO
{
    [CreateAssetMenu(fileName = "New Action Consideration SO", menuName = "UtilityAISystem/Considerations/new Consideration")]
    public abstract class ConsiderationDataSO : ScriptableObject
    {
        [SerializeField] string Name;
        [SerializeField] float Score;
        [SerializeField] AnimationCurve responseCurve;
        public float GetConsiderationScore()
        {
            return Mathf.Clamp01(Score);
        }
        void CalculateConsiderationScore()
        {

        }
    }
}
