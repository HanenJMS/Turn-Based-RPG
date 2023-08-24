using RPGSandBox.InterfaceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class TradingControllerSystem : MonoBehaviour
    {
        public static TradingControllerSystem Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        IAmAUnit playerMerchant;
        private void Start()
        {
            UnitSelectionSystem.Instance.OnSelectedUnit += OnSelectedUnit;
        }

        private void OnSelectedUnit()
        {
            playerMerchant = UnitSelectionSystem.Instance.GetUnit();
        }
    }
}

