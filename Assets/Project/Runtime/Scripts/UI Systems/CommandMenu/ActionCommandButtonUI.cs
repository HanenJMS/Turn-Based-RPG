using RPGSandBox.InterfaceSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionCommandButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Button button;
    [SerializeField] Image image;

    void SetButtonCommandAction(IAmAnAction action, Vector3 location)
    {
        textMeshProUGUI.text = $"{action.ToString()},{location.ToString()}";
    }
    void EnableCommandUI()
    {

    }

}
