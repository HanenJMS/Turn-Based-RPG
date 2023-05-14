using UnityEngine;

namespace RPGSandBox.UtilityAISystem.Core
{
    public class UtilityAIAgent : MonoBehaviour
    {
        UtilityAIActionHandler actionHandler;
        private void Awake()
        {
            actionHandler = GetComponent<UtilityAIActionHandler>();
        }
        void Update()
        {
        }
    }
}

