using RPGSandBox.Controller;
using RPGSandBox.GameUI.MenuButton.Core;
using UnityEngine.UI;
namespace RPGSandBox.GameUI.MenuButton
{
    public class InventoryMenuButtonUI : MenuButtonUI
    {
        public override void AddButtonOnClickListener()
        {
            InterfaceControllerSystem.Instance.ActivateInventoryUI();
        }
    }
}