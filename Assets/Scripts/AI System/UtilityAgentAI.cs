using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentAI : MonoBehaviour
{
    Dictionary<string, int> states = new Dictionary<string, int>();
    public void AddState(string state, int priority)
    {
        if(states.ContainsKey(state)) states[state]+=priority;
        else
        {
            states.Add(state, priority);
        }
    }
    public void RemoveState(string state, int priority)
    {
        if (state == null || state == "") return;
        if (!states.ContainsKey(state)) return;
        if (states[state] >= priority)
        {
            states[state] -= priority;
        }
        if (states[state] == 0)
        {
            states.Remove(state);
        }
    }

    public void ModifyState(string state, int priority)
    {
        if( states.ContainsKey(state))
        {
            if (states[state] <= priority) 
            {
                states[state] += priority;
            }
        }
    }
}
