using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.Controller
{
    public class PlayerUnitActionController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleRightMouseClick();
        }

        private static void HandleRightMouseClick()
        {
            if (Input.GetMouseButtonDown(1))
            {

            }
        }
    }

}

