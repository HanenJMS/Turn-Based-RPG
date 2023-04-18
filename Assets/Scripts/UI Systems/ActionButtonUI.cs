using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Button button;
    BaseAction action;
    [SerializeField] Image image;
    private void Start()
    {
        image.enabled = false;
    }
    public void UnitActionSystem_OnSelectedUnitChanged()
    {
        UpdateVisual();
    }
    public void SetBaseAction(BaseAction baseAction)
    {
        action = baseAction;
        textMeshProUGUI.text = baseAction.GetActionName();
        button.onClick.AddListener(() =>
        {
            UnitActionSystem.Instance.SetSelectedAction(baseAction);
        });
    }
    void UpdateVisual()
    {
        if(UnitActionSystem.Instance.GetCurrentAction() == action)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    void Show()
    {
        image.enabled = true;
    }
    void Hide()
    {
        image.enabled = false;
    }


}
