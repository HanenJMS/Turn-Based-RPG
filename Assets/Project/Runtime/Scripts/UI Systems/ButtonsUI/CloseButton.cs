using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class CloseButton : MonoBehaviour
    {
        IAmAGameUI gameUI;
        Button closeButton;
        private void OnEnable()
        {
            gameUI = GetComponentInParent<IAmAGameUI>();
        }
        private void Start()
        {
            closeButton = GetComponentInChildren<Button>();
            closeButton.onClick.AddListener(() =>
            {
                gameUI.DeActivateUI();
            });
        }
    }
}

