using RPGSandBox.UtilityAISystem.UtilityAISO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.Core
{
    public class UtilityAIActionHandler : MonoBehaviour
    {
        ActionDataSO currentBestAction;
        List<ActionDataSO> actions =  new List<ActionDataSO>();
        List<float> actionScores = new List<float>();
        Dictionary<float, ActionDataSO> weightedActionDictionary = new Dictionary<float, ActionDataSO>();
        public ActionDataSO GetCurrentBestAction()
        {
            StoreActionScorePairs();
            SetBestAction(weightedActionDictionary[actionScores[0]]);
            return currentBestAction;
        }
        public IEnumerator GetActionCoroutine()
        {
            return currentBestAction.GetActionCoroutine();
        }
        void SetBestAction(ActionDataSO actionDataSO)
        {
            currentBestAction = actionDataSO;
        }
        void StoreActionScorePairs()
        {
            actionScores.Clear();
            weightedActionDictionary.Clear();
            foreach(ActionDataSO action in actions)
            {
                weightedActionDictionary.Add(action.GetActionScore(), action);
                actionScores.Add(action.GetActionScore());
            }
            actionScores.Sort();
            actionScores.Reverse();
        }
    }
}
