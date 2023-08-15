using System;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class InterfaceControllerSystem : MonoBehaviour
    {
        public static InterfaceControllerSystem Instance { get; private set; }
        public Action OnActivateInventoryUI;
        public Action OnActivateInformationUI;
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
        }

        private void ToggleInventoryInterfaceUI()
        {
            if (Input.GetKeyUp(KeyCode.B))
            {
                ActivateInventoryUI();
            }
        }
        private void ToggleInformationUI()
        {
            if (Input.GetKeyUp(KeyCode.I))
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
    }
}

