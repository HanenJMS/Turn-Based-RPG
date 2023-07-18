using RPGSandBox.InterfaceSystem;
using UnityEngine;

namespace RPGSandBox.GameUtilities.GameUISystem
{
    public class TooltipTrigger : MonoBehaviour
    {
        IAmInteractable interactable;
        LTDescr delay;
        private void Awake()
        {
            interactable = GetComponent<IAmInteractable>();
        }
        private void OnMouseEnter()
        {
            if (interactable != null)
            {
                delay = LeanTween.delayedCall(0.5f, () =>
                {
                    TooltipSystem.instance.Show(interactable.DescriptionHeader(), interactable.DescriptionContent());
                });
            }
        }
        private void OnMouseExit()
        {
            if (delay == null) return;
            LeanTween.cancel(delay.uniqueId);
            TooltipSystem.instance.Hide();
        }
    }
}

