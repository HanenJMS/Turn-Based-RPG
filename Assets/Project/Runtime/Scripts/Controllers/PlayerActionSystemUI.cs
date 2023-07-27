using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class PlayerActionSystemUI : MonoBehaviour
    {
        [SerializeField] GameObject CommandButtonLayout;
        [SerializeField] ActionCommandButtonUI CommandButtonPrefabs;
        List<ActionCommandButtonUI> ActionCommandButtons = new List<ActionCommandButtonUI>();
        //button
        private void Start()
        {
            PlayerActionSystem.instance.OnMouseRightClick += ActivateUI;
            PlayerActionSystem.instance.OnButtonClick += DeactivateUI;
            PlayerActionSystem.instance.OnMouseLeftClick += DeactivateUI;
            this.gameObject.SetActive(false);

        }
        void ActivateUI(object hit)
        {
            if (PlayerActionSystem.instance.ExecutableActions() == null) return;
            this.gameObject.SetActive(true);
            CommandButtonLayout.GetComponent<RectTransform>().SetPositionAndRotation(Input.mousePosition, this.transform.rotation);

            ClearButtons();
            foreach (IAmAnAction action in PlayerActionSystem.instance.ExecutableActions())
            {
                if (action.CanExecute(hit))
                {
                    ActionCommandButtonUI commandUI = Instantiate(CommandButtonPrefabs, CommandButtonLayout.transform);
                    commandUI.SetButtonCommandAction(action, hit);
                    ActionCommandButtons.Add(commandUI);
                }
            }
        }
        void DeactivateUI()
        {
            ClearButtons();
            this.gameObject.SetActive(false);
        }
        public void ClearButtons()
        {
            foreach (ActionCommandButtonUI button in ActionCommandButtons)
            {
                Destroy(button.gameObject);
            }
            ActionCommandButtons.Clear();
        }
    }
}
