using RPGSandBox.Controller;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class InventoryButton : MonoBehaviour
    {
        Button closeButton;
        private void Start()
        {
            closeButton = GetComponentInChildren<Button>();
            closeButton.onClick.AddListener(() =>
            {
                InterfaceControllerSystem.instance.OnActivateInventoryUI();
            });
        }
    }
}