using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUtilities.GameUISystem
{
    [ExecuteInEditMode()]
    public class Tooltip : MonoBehaviour, IHaveATip
    {
        [SerializeField] TextMeshProUGUI header;
        [SerializeField] TextMeshProUGUI content;
        [SerializeField] LayoutElement layoutElement;
        [SerializeField] int characterWrappingLimit;
        [SerializeField] RectTransform rectTransform;
        [SerializeField] CanvasGroup fadingCanvas;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            header = transform.Find("Header").GetComponent<TextMeshProUGUI>();
            content = transform.Find("Content").GetComponent<TextMeshProUGUI>();
            layoutElement = transform.GetComponent<LayoutElement>();
            fadingCanvas = transform.GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (Application.isEditor)
            {
                int headerLength = header.text.Length;
                int contentLength = content.text.Length;
                layoutElement.enabled = (headerLength > characterWrappingLimit || contentLength > characterWrappingLimit) ? true : false;
            }
            Vector2 position = Input.mousePosition;
            float pivotX = position.x / Screen.width;
            float pivotY = position.y / Screen.height;
            rectTransform.pivot = new Vector2(pivotX, pivotY);

            transform.position = position;
        }
        public void Show()
        {
            this.gameObject.SetActive(true);
            LeanTween.alphaCanvas(fadingCanvas, 1, 0.5f);
        }
        public void Hide()
        {
            this.gameObject.SetActive(false);
            LeanTween.alphaCanvas(fadingCanvas, 0, 0.5f);
        }
        public void SetTooltipText(string headerText, string contentText)
        {
            if (string.IsNullOrEmpty(headerText))
            {
                this.header.gameObject.SetActive(false);
            }
            else
            {
                this.header.gameObject.SetActive(true);

                this.header.text = headerText;
            }
            this.content.text = contentText;


            int headerLength = header.text.Length;
            int contentLength = content.text.Length;
            layoutElement.enabled = (headerLength > characterWrappingLimit || contentLength > characterWrappingLimit) ? true : false;
        }
    }

}
