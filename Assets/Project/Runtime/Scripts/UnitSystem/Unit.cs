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

        IAmAnItem itemTarget = null;
        bool withinRange = false;
        private void Awake()
        {
            Initialization();
        }
        private void Update()
        {
            TryToGrab();
        }


        public void Move(Vector3 destination)
        {
            mover.MoveToDestination(destination);
        }
        public void Speak(string message, bool priority)
        {
            voice.Speaking(message, priority);
        }
        public void Grab(IAmAnItem item)
        {
            withinRange = IsInRange(item);
            
            if (!withinRange)
            {
                itemTarget = item;
                return;
            }
            if (item.CanBePickedUp())
            {
                inventory.StoreItem(item);
                Speak("I grabbed something.", true);
            }
            else if (!item.CanBePickedUp())
            {
                Speak("Uhh... There is no item here", true);
            }
            itemTarget = null;
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
        private bool IsInRange(IAmAnItem item)
        {
            float pickUpDistance = 1f;
            return Vector3.Distance(item.MyPosition(), MyPosition()) < pickUpDistance;
        }
        private void TryToGrab()
        {
            if (itemTarget == null) return;
            if (!withinRange)
            {
                Move(itemTarget.MyPosition());
            }
            Grab(itemTarget);
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
            inventory = GetComponent<IHaveAnInventory>();
            mover = GetComponent<ICanMove>();
            voice = GetComponentInChildren<ICanSpeak>();
        }
    }
}

