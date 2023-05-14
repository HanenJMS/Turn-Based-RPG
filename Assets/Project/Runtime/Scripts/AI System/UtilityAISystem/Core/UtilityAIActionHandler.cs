using RPGSandBox.UtilityAISystem.UtilityAISO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.UtilityAISystem.Core
{
    public class UtilityAIActionHandler : MonoBehaviour
    {
        ActionDataSO currentAction;
        [SerializeField] List<ActionDataSO> actions = new List<ActionDataSO>();

        //ancillary data holders
        Dictionary<float, ActionDataSO> weightedActionDictionary = new Dictionary<float, ActionDataSO>();
        List<float> actionScores = new List<float>();
        public bool HasRunningAction()
        {
            return currentAction.IsRunning();
        }

        public void Execute()
        {
            currentAction.Execute();
        }
        private void Update()
        {

        }
        IEnumerator GetActionCoroutine()
        {
            return currentAction.GetActionCoroutine();
        }
        bool IsBestActionSet()
        {
            ActionDataSO bestAction = weightedActionDictionary[actionScores[0]];
            if (bestAction == null) return false;
            SetCurrentAction(bestAction);
            return true;
        }
        void CalculateAndSortActionScore()
        {
            if (!IsThisInitialized()) return;
            if (!IsActionDataCleared()) return;
            if (!IsActionSorted()) return;
            if (!IsBestActionSet()) return;
        }
        void SetCurrentAction(ActionDataSO actionDataSO)
        {
            currentAction = actionDataSO;
        }

        private bool IsActionSorted()
        {
            foreach (ActionDataSO action in actions)
            {
                if (action == null) return false;
                float key = action.GetActionScore();
                weightedActionDictionary.Add(key, action);
                actionScores.Add(key);
            }
            actionScores.Sort();
            actionScores.Reverse();
            return true;
        }

        private bool IsActionDataCleared()
        {
            actionScores.Clear();
            weightedActionDictionary.Clear();
            return true;
        }
        private bool IsThisInitialized()
        {
            if (actionScores == null)
            {
                Debug.Log("UtilityAIActionHandler.cs is missing a list of actionScores. ClearCurrentData()");
                return false;
            }
            if (weightedActionDictionary == null)
            {
                Debug.Log("UtilityAIActionHandler.cs is missing a weighted dictionary. ClearCurrentData()");
                return false;
            }
            return true;
        }
    }
}
