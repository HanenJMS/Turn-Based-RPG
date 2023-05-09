using UnityEngine;

namespace RPGSandBox.UtilityAISystem.Core
{
    public class UtilityAIAgent : MonoBehaviour
    {
        UtilityAIActionHandler actionHandler;
        Coroutine currentCoroutine;
        private void Awake()
        {
            GetComponent<UtilityAIActionHandler>();
        }
        void Update()
        {
            if (actionHandler == null) return;
            if (currentCoroutine == null) {  return; }
            currentCoroutine = StartCoroutine(actionHandler.GetActionCoroutine());
        }
    }
}

