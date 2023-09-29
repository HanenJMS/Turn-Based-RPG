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
    public void SetButtonCommandAction(IAmAnAction action, object target)
    {
        this.action = action;
        actionTarget = target.ToString();
        actionName = action.ActionName();
        if (target is IAmInteractable)
        {
            IAmInteractable interactableObject = (IAmInteractable)target;
            actionTarget = $"({interactableObject.InteractableName()})";
        }
        actionButtonName.text = $"{actionName}{actionTarget}";
        button.onClick.AddListener(() =>
        {
            PlayerActionControllerSystem.Instance.ExecuteAction(this.action, target);
        });
    }
}
