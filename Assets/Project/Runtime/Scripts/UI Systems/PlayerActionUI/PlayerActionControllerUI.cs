using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class PlayerActionControllerUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField] RectTransform CommandButtonLayout;
        [SerializeField] ActionCommandButtonUI CommandButtonPrefabs;
        List<ActionCommandButtonUI> ActionCommandButtons = new List<ActionCommandButtonUI>();
        //button
        private void Start()
        {
            PlayerActionController.Instance.OnMouseRightClick += ActivateUI;
            PlayerActionController.Instance.OnButtonClick += DeActivateUI;
            PlayerActionController.Instance.OnMouseLeftClick += DeActivateUI;
            this.gameObject.SetActive(false);

        }
        void ActivateUI(object hit)
        {
            if (PlayerActionController.Instance.ExecutableActions() == null) return;
            ActivateUI();

            CommandButtonLayout.GetComponent<RectTransform>().SetPositionAndRotation(Input.mousePosition, this.transform.rotation);

            ClearUI();
            foreach (IAmAnAction action in PlayerActionController.Instance.ExecutableActions())
            {
                if (action.CanExecute((object)hit))
                {
                    ActionCommandButtonUI commandUI = Instantiate(CommandButtonPrefabs, CommandButtonLayout);
                    commandUI.SetButtonCommandAction(action, hit);
                    ActionCommandButtons.Add(commandUI);
                }
            }
             
        }
        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
        }
        public void DeActivateUI()
        {
            ClearUI();
            this.gameObject.SetActive(false);
        }
        public void ClearUI()
        {
            foreach (ActionCommandButtonUI button in ActionCommandButtons)
            {
                Destroy(button.gameObject);
            }
            ActionCommandButtons.Clear();
        }
    }
}
