using RPGSandBox.InterfaceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static Codice.Client.Common.WebApi.WebApiEndpoints;

namespace RPGSandBox.GameUtilities.GameUISystem
{
    public class ChatBubble : MonoBehaviour, ICanSpeak
    {

        [SerializeField] SpriteRenderer background;
        [SerializeField] SpriteRenderer icon;
        [SerializeField] TextMeshPro textpro;
        private void Awake()
        {
            background = transform.Find("Background").GetComponent<SpriteRenderer>();
            icon = transform.Find("Icon").GetComponent<SpriteRenderer>();
            textpro = transform.Find("Text").GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            
            
        }
        private void Update()
        {
            
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
        public void Speaking(string text)
        {
            this.gameObject.SetActive(true);
            Setup(text);
        }
        void Setup(string text)
        {
            textpro.SetText(text);
            textpro.ForceMeshUpdate();
            Vector2 textSize = textpro.GetRenderedValues(false);
            Vector2 padding = textSize * 0.20f;
            background.size = textSize + padding;

            Vector2 offset = new Vector2(-padding.x / 2, 0f);
            icon.transform.localPosition = new Vector2(-background.size.x / 2f, 0f) + offset;
            
        }
    }
}


