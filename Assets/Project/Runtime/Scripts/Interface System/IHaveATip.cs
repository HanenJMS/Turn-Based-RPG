namespace RPGSandBox.InterfaceSystem
{
    public interface IHaveATip
    {
        void Show();
        void Hide();
        void SetTooltipText(string headerText, string contentText);
    }
}

