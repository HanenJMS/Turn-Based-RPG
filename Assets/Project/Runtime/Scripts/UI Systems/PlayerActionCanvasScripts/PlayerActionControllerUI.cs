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
            PlayerActionControllerSystem.Instance.OnMouseRightClick += ActivateUI;
            PlayerActionControllerSystem.Instance.OnButtonClick += DeActivateUI;
            PlayerActionControllerSystem.Instance.OnMouseLeftClick += DeActivateUI;
            this.gameObject.SetActive(false);

        }
        void ActivateUI(object hit)
        {
            if (PlayerActionControllerSystem.Instance.ExecutableActions() == null) return;
            ActivateUI();

            CommandButtonLayout.GetComponent<RectTransform>().SetPositionAndRotation(Input.mousePosition, this.transform.rotation);

            ClearUI();
            foreach (IAmAnAction action in PlayerActionControllerSystem.Instance.ExecutableActions())
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

        public void UpdateUI()
        {
            throw new System.NotImplementedException();
        }
    }
}
