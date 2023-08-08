using Codice.Client.Common;
using RPGSandBox.InterfaceSystem;
using UnityEngine;


namespace RPGSandBox.GameUtilities.GameUISystem
{
    public class TooltipSystem : MonoBehaviour
    {
        IHaveATip tooltip;
        public static TooltipSystem instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            tooltip = GetComponentInChildren<IHaveATip>();
            tooltip.Hide();
        }
        public void Show(string header, string content)
        {
            tooltip.SetTooltipText(header, content);
            tooltip.Show();
        }
        public void Hide()
        {
            tooltip.Hide();
        }
    }
}

