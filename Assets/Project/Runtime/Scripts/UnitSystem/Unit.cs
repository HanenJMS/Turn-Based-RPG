using RPGSandBox.InterfaceSystem;
using UnityEngine;


namespace RPGSandBox.UnitSystem
{
    public class Unit : MonoBehaviour, IAmAUnit
    {
        [SerializeField] Inventory_Old inventory;
        ICanMove mover;
        ICanSpeak voice;
        private void Awake()
        {
            Initialization();
        }
        public void Move(Vector3 destination)
        {
            mover.MoveToDestination(destination);
        }
        public void Speak(string message, bool priority)
        {
            voice.Speaking(message, priority);
        }

        public bool IsSelected()
        {
            bool isSelected = false;
            if (UnitSelectionSystem.Instance.GetUnit() == this.gameObject.GetComponent<IAmAUnit>())
            {
                isSelected = true;
            }
            return isSelected;
        }

        private void Initialization()
        {
            if (!IsInitialized())
            {
                Initialize();
            }
        }
        private bool IsInitialized()
        {
            if (mover == null) return false;
            if (inventory == null) return false;
            return true;
        }
        private void Initialize()
        {
            inventory = GetComponent<Inventory_Old>();
            mover = GetComponent<ICanMove>();
            voice = GetComponentInChildren<ICanSpeak>();
        }
    }
}

