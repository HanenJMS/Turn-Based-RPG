using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionCommandButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI actionName, actionTarget;
    [SerializeField] Button button;
    [SerializeField] Image image;
    IAmAnAction action;
    public void SetButtonCommandAction(IAmAnAction action, object interactable)
    {
        this.action = action;
        actionName.text = action.ActionName();
        actionTarget.text = interactable.GetType().ToString();
        button.onClick.AddListener(() =>
        {
            PlayerActionSystem.instance.ExecuteAction(this.action, interactable);
        });
    }
    public void DisableUI()
    {
        Destroy(this);
    }

}
