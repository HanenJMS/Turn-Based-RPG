using System.Collections.Generic;

namespace RPGSandBox.GameAISystem
{
    [System.Serializable]
    public class WorldState
    {
        public string key;
        public int value;
    }


    public class WorldStates
    {
        Dictionary<string, int> states = new();
        bool ContainState(string key)
        {
            return states.ContainsKey(key);
        }
        void ModifyState(string key, int value)
        {
            if (!ContainState(key)) AddState(key, value);
            states[key] += value;
        }
        void AddState(string key, int value)
        {
            states.Add(key, value);
        }
        void RemoveState(string key, int value)
        {
            states[key] -= value;
        }
        void SetState(string key, int value)
        {
            if (!ContainState(key)) AddState(key, value);
            else
            {
                states[key] = value;
            }
        }
        Dictionary<string, int> GetStates()
        {
            return states;
        }
    }
}

