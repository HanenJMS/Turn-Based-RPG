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
        [SerializeField] IAmInteractable selectedInteractable;
        private void Start()
        {
            InterfaceControllerSystem.instance.OnActivateInformationUI += ToggleUI;
        }

        private void Onselected(IAmInteractable interactable)
        {
            selectedInteractable = interactable;
            UpdateUI();
        }
        void UpdateUI()
        {
            ClearUI();
            if (selectedInteractable != null)
            {
                Header.text = selectedInteractable.InteractableName();
                Body.text = selectedInteractable.DescriptionContent();
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

