using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionCommandButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI actionButtonName;
    string actionName="", actionTarget="";
    [SerializeField] RectTransform actionRectTransform;
    [SerializeField] Button button;
    [SerializeField] Image image;

    IAmAnAction action;
    public void SetButtonCommandAction(IAmAnAction action, object interactable)
    {
        this.action = action;
        actionTarget = interactable.ToString();
        actionName = action.ActionName();
        if (interactable is IAmInteractable)
        {
            IAmInteractable interactableObject = (IAmInteractable)interactable;
            actionTarget = $"({interactableObject.InteractableName()})";
        }
        actionButtonName.text = $"{actionName}{actionTarget}";
        button.onClick.AddListener(() =>
        {
            PlayerActionController.Instance.ExecuteAction(this.action, interactable);
        });
    }
}
