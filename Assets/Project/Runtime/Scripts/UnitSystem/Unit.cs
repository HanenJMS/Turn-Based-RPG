using RPGSandBox.InterfaceSystem;
using System;
using UnityEngine;


namespace RPGSandBox.UnitSystem
{
    public class Unit : MonoBehaviour, IAmAUnit
    {
        IHaveAnInventory inventory;

        ICanMove mover;
        ICanSpeak voice;
        ICanGather gatherer;

        private void Awake()
        {
            Initialization();
        }


        public void Move(Vector3 destination)
        {
            mover.MovingTo(destination);
        }
        public void Speak(string message, bool priority)
        {
            voice.Saying(message, priority);
        }
        public void Gather(IAmAnItem item)
        {
            gatherer.Gathering(this, item);
        }
        public void Store(IAmAnItem item)
        {
            inventory.Storing(item);
        }
        public void Interact(IAmInteractable interact)
        {

        }
        public Vector3 MyPosition()
        {
            return this.transform.position;
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
            if (gatherer == null) return false;
            return true;
        }
        private void Initialize()
        {
            inventory = GetComponent<IHaveAnInventory>();
            mover = GetComponent<ICanMove>();
            voice = GetComponentInChildren<ICanSpeak>();
            gatherer = GetComponent<ICanGather>();
        }
    }
}

