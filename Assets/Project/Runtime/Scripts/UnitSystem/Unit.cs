using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;


namespace RPGSandBox.UnitSystem
{
    public class Unit : MonoBehaviour, IAmAUnit
    {
        IAmAnInventory inventory;

        //actions
        ICanMove mover;
        ICanSpeak voice;
        ICanCraft crafter;
        ICanGather gatherer;
        ICanTrade trader;


        IHaveAnAction myAction;
        IHaveATarget targeter;
        private void Awake()
        {
            Initialization();
        }
        public ICanTrade Trader()
        {
            return trader;
        }
        public ICanMove Mover()
        {
            return mover;
        }
        public ICanCraft Crafter()
        {
            return crafter;
        }
        public ICanGather Gatherer()
        {
            return gatherer;
        }
        public IHaveATarget Targeter()
        {
            return targeter;
        }
        public IAmAnInventory Inventory()
        {
            return inventory;
        }
        public void Speak(string message, bool priority)
        {
            voice.Saying(message, priority);
        }
        public void Execute(IAmAnAction action)
        {
            myAction.Executing(action);
        }
        public bool IsSelected()
        {
            return UnitSelectionSystem.Instance.GetUnit() == this.gameObject.GetComponent<IAmAUnit>();
        }
        public bool CanInteract(IAmInteractable interact)
        {
            return false;
        }
        public Vector3 MyPosition()
        {
            return this.transform.position;
        }
        public string DescriptionHeader()
        {
            return this.gameObject.name;
        }
        public string DescriptionContent()
        {
            return this.gameObject.GetComponent<IAmAUnit>().GetType().ToString();
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
            if (myAction == null) return false;
            if (targeter == null) return false;
            if (trader == null) return false;
            return true;
        }
        private void Initialize()
        {
            inventory = GetComponent<IAmAnInventory>();
            mover = GetComponent<ICanMove>();
            voice = GetComponentInChildren<ICanSpeak>();
            gatherer = GetComponent<ICanGather>();
            crafter = GetComponent<ICanCraft>();
            myAction = GetComponent<IHaveAnAction>();
            targeter = GetComponent<IHaveATarget>();
            trader = GetComponent<ICanTrade>();
        }
        public List<IAmAnAction> ActionList()
        {
            return myAction.MyActionsList();
        }
        public string InteractableName()
        {
            return this.gameObject.name;
        }
    }
}

