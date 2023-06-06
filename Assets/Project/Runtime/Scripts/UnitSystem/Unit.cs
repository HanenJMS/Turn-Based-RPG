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
        ICanCraft crafter;
        ICanGather gatherer;

        IHaveAnAction actioner;
        private void Awake()
        {
            Initialization();
        }

        //Actions
        public void Move(Vector3 destination)
        {
            mover.Moving(destination);
        }
        public void Speak(string message, bool priority)
        {
            voice.Saying(message, priority);
        }
        public void Craft(IAmACraftingStation station)
        {
            crafter.Crafting(this, station);
        }
        public void Gather(IAmAnItem item)
        {
            gatherer.Gathering(this, item);
        }
        public void Store(IAmAnItem item)
        {
            inventory.Storing(item);
        }
        public void Remove(IAmAnItem item, int qty)
        {
            inventory.Removing(item, qty);
        }
        public bool Check(IAmAnItem item, int qty)
        {
            return inventory.Checking(item, qty);
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

        public void Execute(IAmAnAction action)
        {
            actioner.Executing(action);
        }
        public void SetToMove(Vector3 destination)
        {
            mover.SetToMoving(destination);
        }
        public void Interact(IAmInteractable interact)
        {

        }
        public Vector3 MyPosition()
        {
            return this.transform.position;
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
            if (crafter == null) return false;
            if (actioner == null) return false;
            return true;
        }
        private void Initialize()
        {
            inventory = GetComponent<IHaveAnInventory>();
            mover = GetComponent<ICanMove>();
            voice = GetComponentInChildren<ICanSpeak>();
            gatherer = GetComponent<ICanGather>();
            crafter = GetComponent<ICanCraft>();
            actioner = GetComponent<IHaveAnAction>();
        }
    }
}
