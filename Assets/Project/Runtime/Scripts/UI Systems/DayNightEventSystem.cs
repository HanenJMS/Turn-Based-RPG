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
        
        [SerializeField] float currentExposureValue = 0f;
        [SerializeField] float currentAtmosphereThickness = 0f;

        //properties

        //day
        float dayExposureValue = 2.3f;
        float dayAtmoThickness = 0.55f;

        //night
        float nightExposureValue = 0.5f;
        float nightAtmoThickness = 0.25f;

        //controllers
        bool isDay = true;
        bool isTransitioning = false;

        void SunriseTransition()
        {
            isTransitioning = true;
            currentExposureValue = 0.5f;
            currentAtmosphereThickness = 0.25f;
            day.SetActive(true);
        }
        void SunsetTransition()
        {
            isTransitioning = true;
            currentExposureValue = 2.3f;
            currentAtmosphereThickness = 0.55f;
        }

        void MoonriseTransition()
        {
            night.SetActive(true);
            day.SetActive(false);
        }
        void Moonset()
        {
            night.SetActive(false);
        }
        void Sunset()
        {
            day.SetActive(false);
        }
        private void Update()
        {
            if(isTransitioning)
            {
                RenderSettings.skybox.SetFloat("_Exposure", currentExposureValue);
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", currentAtmosphereThickness);
            }
        }

        void TransitionComplete()
        {
            isTransitioning = false;
        }
    }
}

