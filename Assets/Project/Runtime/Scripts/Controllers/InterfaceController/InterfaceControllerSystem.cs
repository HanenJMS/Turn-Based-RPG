using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class InterfaceControllerSystem : MonoBehaviour
    {
        public static InterfaceControllerSystem Instance { get; private set; }
        public Action OnActivateInventoryUI;
        public Action OnActivateMapUI;
        public Action OnActivateQuestListUI;
        public Action OnActivateInformationUI;
        public Action OnActivateTradeUI;
        public Action<IAmAnInventorySlot> OnActivateItemInteractionWindowUI;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        private void Update()
        {
            HandleInterface();
        }
        void HandleInterface()
        {
            ToggleInformationUI();
            ToggleInventoryInterfaceUI();
            ToggleMapUI();
            ToggleQuestlListUI();
        }

        private void ToggleQuestlListUI()
        {
            if (Input.GetKeyUp(KeyCode.J))
            {
                ActivateQuestListUI();
            }
        }

        private void ToggleMapUI()
        {
            if(Input.GetKeyUp(KeyCode.M))
            {
                ActivateMapUI();
            }
        }

        private void ToggleInventoryInterfaceUI()
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                ActivateInventoryUI();
            }
        }
        private void ToggleInformationUI()
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                ActivateInformationUI();
            }
        }
        public void ActivateInventoryUI()
        {
            OnActivateInventoryUI?.Invoke();
        }
        public void ActivateInformationUI()
        {
            OnActivateInformationUI?.Invoke();
        }
        public void ActivateMapUI()
        {
            OnActivateMapUI?.Invoke();
        }
        public void ActivateQuestListUI()
        {
            OnActivateQuestListUI?.Invoke();
        }
        public void ActivateTradeUI()
        {
            OnActivateTradeUI?.Invoke();
        }
        public void ActivateItemInteractionWindowUI(IAmAnInventorySlot slot)
        {
            OnActivateItemInteractionWindowUI?.Invoke(slot);
        }
    }
}

