using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.UtilityAISO
{
    public abstract class ActionDataSO : ScriptableObject
    {
        public string Name { get; private set; }
        [SerializeField] float Score;
        [SerializeField] List<ConsiderationDataSO> Considerations = new List<ConsiderationDataSO>();

        public void Execute()
        {

        }
        public abstract IEnumerator GetActionCoroutine();
        public bool IsRunning()
        {
            return false;
        }
        public float GetActionScore()
        {
            CalculateActionConsiderationScore();
            return Mathf.Clamp01(Score);
        }
        void CalculateActionConsiderationScore()
        {
            float score = 1f;
            foreach (ConsiderationDataSO consideration in Considerations)
            {
                score *= consideration.GetConsiderationScore();
            }
            Score = score;
            if (Score == 0) return;
            NormalizeScore(score);
        }
        private void NormalizeScore(float score)
        {
            float originalScore = score;
            float modFactor = 1 - (1 / Considerations.Count);
            float makeupValue = (1 - originalScore) * modFactor;
            Score = originalScore + (makeupValue * originalScore);
        }
    }
}


