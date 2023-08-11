using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameCanvas
{
    public class GameCanvasAutoScaler : MonoBehaviour
    {
        [SerializeField] List<RectTransform> gameCanvas = new List<RectTransform>();
        [SerializeField] RectTransform thisCanvasTransform;
        [SerializeField] Vector2 canvasResolution;
        [SerializeField] Vector3 thisCanvasScaling;
        private void Awake()
        {
            thisCanvasTransform = GetComponent<RectTransform>();
            thisCanvasScaling = GetComponent<RectTransform>().localScale;
            canvasResolution = GetComponent<RectTransform>().sizeDelta;
        }
        private void Start()
        {
            ScaleTheCanvas();
        }
        private void Update()
        {
            if (canvasResolution == GetComponent<RectTransform>().sizeDelta) return;
            ScaleTheCanvas();
        }
        private void ScaleTheCanvas()
        {

            foreach (RectTransform rectTransform in gameCanvas)
            {
                rectTransform.sizeDelta = canvasResolution;
                rectTransform.localScale = thisCanvasScaling;
            }
        }
    }
}

