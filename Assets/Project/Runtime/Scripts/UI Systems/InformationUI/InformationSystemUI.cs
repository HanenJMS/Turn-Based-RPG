using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class InformationSystemUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] TextMeshProUGUI Header;
        [SerializeField] TextMeshProUGUI Body;
        [SerializeField] IAmInteractable interactable;
        private void Start()
        {
            InterfaceControllerSystem.Instance.OnActivateInformationUI += ToggleUI;
            InteractableControllerSystem.Instance.OnInteractableSelcted += Onselected;
        }

        private void Onselected()
        {
            this.interactable = InteractableControllerSystem.Instance.GetSelected();
            UpdateUI();
        }
        public void UpdateUI()
        {
            ClearUI();
            if (interactable != null)
            {
                Header.text = interactable.GetInteractableData().GetInteractableName();
                Body.text = interactable.GetInteractableData().GetInteractableDescription();
            }
        }
        void ToggleUI()
        {
            if (this.gameObject.activeSelf)
            {
                DeActivateUI();
            }
            else if (!this.gameObject.activeSelf)
            {
                ActivateUI();
            }
        }
        public void ClearUI()
        {
            Header.text = "";
            Body.text = "";
        }
        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
            UpdateUI();
        }
        public void DeActivateUI()
        {
            UpdateUI();
            this.gameObject.SetActive(false);
        }
    }
}

