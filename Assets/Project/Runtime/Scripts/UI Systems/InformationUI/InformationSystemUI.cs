using RPGSandBox.InteractableSystem;
using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;

namespace RPGSandBox.GameUI
{
    public class InformationSystemUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Header;
        [SerializeField] TextMeshProUGUI Body;
        [SerializeField] IAmInteractable selectedInteractable;
        private void Start()
        {
            InteractableSelectionSystem.instance.OnActivateInteractableUI += ToggleUI;
            InteractableSelectionSystem.instance.OnInteractableSelected += Onselected;
            InteractableSelectionSystem.instance.OnClearUI += ClearUI;
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
                DeactivateUI();
            }
            else if (!this.gameObject.activeSelf)
            {
                ActivateUI();
            }
        }
        void ClearUI()
        {
            Header.text = "";
            Body.text = "";
        }
        private void ActivateUI()
        {
            this.gameObject.SetActive(true);
            UpdateUI();
        }
        private void DeactivateUI()
        {
            UpdateUI();
            this.gameObject.SetActive(false);
        }
    }
}

