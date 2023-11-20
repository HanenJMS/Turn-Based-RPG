using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;

namespace RPGSandBox.GameUtilities.GameUISystem
{
    public class ChatBubble_Old : MonoBehaviour, ICanSpeak
    {

        [SerializeField] SpriteRenderer background;
        [SerializeField] SpriteRenderer icon;
        [SerializeField] TextMeshPro textpro;
        float speechTimeLength = 0f;
        float speechTimer = 0f;
        private void Awake()
        {
            background = transform.Find("Background").GetComponent<SpriteRenderer>();
            icon = transform.Find("Icon").GetComponent<SpriteRenderer>();
            textpro = transform.Find("Text").GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            this.gameObject.SetActive(false);
        }
        private void Update()
        {
            HandleSpeechBubbleWhenActive();
        }

        private void HandleSpeechBubbleWhenActive()
        {
            if (!this.gameObject.activeSelf) return;
            if (speechTimer < speechTimeLength)
            {
                speechTimer += Time.deltaTime * 1f;
                transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
            }
            if (speechTimer >= speechTimeLength)
            {
                this.gameObject.SetActive(false);
            }
        }

        public void Saying(string message, bool priority)
        {
            if (this.gameObject.activeSelf && !priority) return;
            this.gameObject.SetActive(true);

            SetupSpeechBubble(message);
            StartSpeechTimer(message);
        }

        private void StartSpeechTimer(string message)
        {
            string[] messageNumberOfWords = message.Split(' ');
            speechTimeLength = messageNumberOfWords.Length;
            speechTimer = 0f;
        }

        void SetupSpeechBubble(string text)
        {
            textpro.SetText(text);
            textpro.ForceMeshUpdate();
            SetupSpeechBubbleSize();
        }

        private void SetupSpeechBubbleSize()
        {
            Vector2 textSize = textpro.GetRenderedValues(false);
            Vector2 padding = textSize * 0.20f;
            background.size = textSize + padding;
            Vector2 offset = new (-padding.x / 2, 0f);
            icon.transform.localPosition = new Vector2(-background.size.x / 2f, 0f) + offset;
        }

        public void Cancel()
        {

        }

        public void Execute(object t)
        {
            throw new System.NotImplementedException();
        }

        public bool CanExecute(object target)
        {
            return false;
        }

        public string ActionName()
        {
            return "Say Something";
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void SetTarget(IAmInteractable target)
        {
            throw new System.NotImplementedException();
        }

        public void SetTarget(object target)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExecuting()
        {
            throw new System.NotImplementedException();
        }
    }
}


