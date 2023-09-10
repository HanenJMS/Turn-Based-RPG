using RPGSandBox.Controller;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI
{
    public class InventoryButton : MonoBehaviour
    {
        Button inventoryButton;
        private void Start()
        {
            inventoryButton = GetComponentInChildren<Button>();
            inventoryButton.onClick.AddListener(() =>
            {
                InterfaceControllerSystem.Instance.OnActivateInventoryUI();
            });
        }
    }
}