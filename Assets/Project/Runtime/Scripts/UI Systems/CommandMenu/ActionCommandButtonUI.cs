using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionCommandButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI actionName, actionTarget;
    [SerializeField] RectTransform actionRectTransform;
    [SerializeField] Button button;
    [SerializeField] Image image;

    IAmAnAction action;
    public void SetButtonCommandAction(IAmAnAction action, object interactable)
    {
        this.action = action;
        actionName.text = action.ActionName();
        actionTarget.text = interactable.ToString();
        if (interactable is IAmInteractable)
        {
            IAmInteractable interactableObject = (IAmInteractable)interactable;
            actionTarget.text = $"({interactableObject.InteractableName()})";
        }

        button.onClick.AddListener(() =>
        {
            PlayerActionSystem.instance.ExecuteAction(this.action, interactable);
        });
    }
}
