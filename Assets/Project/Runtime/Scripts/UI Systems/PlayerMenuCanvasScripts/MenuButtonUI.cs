using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RPGSandBox.GameUI.MenuButton.Core
{
    public abstract class MenuButtonUI : MonoBehaviour
    {
        Button menuButton;
        // Start is called before the first frame update
        void Start()
        {
            menuButton = GetComponent<Button>();
            menuButton.onClick.AddListener(() =>
            {
                AddButtonOnClickListener();
            });
        }

        public abstract void AddButtonOnClickListener();
    }
}


