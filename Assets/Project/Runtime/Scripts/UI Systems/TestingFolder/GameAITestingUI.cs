using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace RPGSandBox.GameCanvas
{
    public class GameAITestingUI : MonoBehaviour
    {
        IAmAUnit selectedUnit;
        [SerializeField]TextMeshProUGUI currentUnit;
        [SerializeField]TextMeshProUGUI currentAction;
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }

        private void Update()
        {
            if(selectedUnit != null)
            {
                currentAction.text = selectedUnit.Actioner().CurrentActionName();
            }
        }
        private void OnSelectedUnit()
        {
            selectedUnit = UnitSelectionSystem.Instance.GetUnit();
            currentUnit.text = selectedUnit.InteractableName();
        }
    }
}

