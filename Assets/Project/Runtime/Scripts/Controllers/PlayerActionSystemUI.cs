using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.Controller
{
    public class PlayerActionSystemUI : MonoBehaviour
    {
        [SerializeField] GameObject ActionCommandButtonLayout;
        [SerializeField] GameObject ActionCommandButtonPrefabs;
        //button
        private void Start()
        {
            PlayerActionSystem.instance.OnMouseRightClick += ActivateUI;
        }
        void ActivateUI()
        {
            this.gameObject.SetActive(true);
        }
    }
}
