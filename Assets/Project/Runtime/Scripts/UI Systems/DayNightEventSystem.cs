using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

namespace RPGSandBox.GameUI
{
    public class DayNightEventSystem : MonoBehaviour
    {
        [SerializeField] GameObject day;
        [SerializeField] GameObject night;
        [SerializeField] Material dayNightMaterial;

        bool isDay = true;


        void TriggerDayNight()
        {
            isDay = !isDay;
            if(isDay)
            {
                RenderSettings.skybox.SetFloat("SunSize", 0.05f);
                RenderSettings.skybox.SetFloat("Exposure", 2.3f);
                day.SetActive(true);
                night.SetActive(false);
            }
            if (!isDay)
            {
                RenderSettings.skybox.SetFloat("Exposure", 0.02f);
                RenderSettings.skybox.SetFloat("SunSize", 0.03f);
                night.SetActive(true);
                day.SetActive(false);
            }
        }
    }
}

