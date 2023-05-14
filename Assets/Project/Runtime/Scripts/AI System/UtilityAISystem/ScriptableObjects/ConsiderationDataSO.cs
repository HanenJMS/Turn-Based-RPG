using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAISO
{
    public abstract class ConsiderationDataSO : ScriptableObject
    {
        [SerializeField] string Name;
        [SerializeField] AnimationCurve responseCurve;
        float Score;
        public float GetConsiderationScore()
        {
            CalculateConsiderationScore();
            return Mathf.Clamp01(Score);
        }
        public abstract void CalculateConsiderationScore();
        public void SetScore(float score)
        {
            this.Score = score;
        }
    }
}
