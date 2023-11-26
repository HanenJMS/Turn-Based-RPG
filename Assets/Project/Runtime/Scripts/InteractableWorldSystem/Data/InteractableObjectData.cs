using UnityEngine;

namespace RPGSandBox.InteractableWorldSystem
{
    public class InteractableObjectData : ScriptableObject
    {
        [SerializeField] string interactableName;
        [TextArea(15, 20)]
        [SerializeField] string interactableDescription;

        [SerializeField] GameObject interactableModelPrefab;
        [SerializeField] Sprite interactableSprite;
        [SerializeField] InteractableType interactableType = InteractableType.Interactable;
        public string GetInteractableName()
        {
            return interactableName;
        }

        public string GetInteractableDescription()
        {
            return interactableDescription;
        }

        public GameObject GetInteractableModelPrefab()
        {
            return interactableModelPrefab;
        }

        public Sprite GetInteractableSprite()
        {
            return interactableSprite;
        }

        public InteractableType GetInteractableType()
        {
            return interactableType;
        }
    }
}
