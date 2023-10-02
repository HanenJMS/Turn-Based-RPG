using RPGSandBox.Controller;
using RPGSandBox.GameUI.MenuButton.Core;
namespace RPGSandBox.GameUI.MenuButton
{
    public class MapMenuButtonUI : MenuButtonUI
    {
        public override void AddButtonOnClickListener()
        {
            InterfaceControllerSystem.Instance.ActivateMapUI();
        }
    }
}