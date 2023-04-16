using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAIQuestingBehaviour : MonoBehaviour
{
    List<Quest> inCompletedQuests = new List<Quest>();
    [SerializeField] UtilityAgentAI agent;
    [SerializeField] int mininumQuestsThreshold = 0;
    [SerializeField] int maximumQuestsThreshold = 3;
    [SerializeField] int expectedQuestThreshold;
    [SerializeField] string state ="FindAQuest";
    private void Awake()
    {
        agent = GetComponent<UtilityAgentAI>();
    }
    // Update is called once per frame
    void Update()
    {
        //ask if there are any quests currently incomplete
        if(inCompletedQuests.Count <= mininumQuestsThreshold)
        {
            //change state or add state to look for more quests
            ChangeStateOrAddState();
        }
    }

    private void ChangeStateOrAddState()
    {
        expectedQuestThreshold = CalculateQuestThreshold();
        agent.AddState(state, expectedQuestThreshold);
    }

    private int CalculateQuestThreshold()
    {
        throw new NotImplementedException();
    }
}
