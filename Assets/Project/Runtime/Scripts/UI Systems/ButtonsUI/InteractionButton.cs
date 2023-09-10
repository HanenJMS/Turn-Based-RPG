using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public class InteractionButton : MonoBehaviour
    {
        Button button;
        private void Awake()
        {
            button = GetComponent<Button>();
        }


    }
}

