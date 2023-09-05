using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;


namespace RPGSandBox.UnitSystem
{
    public class Unit : MonoBehaviour, IAmAUnit
    {
        IAmAnInventory inventory;
        IAmATrader trader;
        //actions
        ICanMove movingAction;
        ICanSpeak speakingAction;
        ICanCraft craftingAction;
        ICanGather gatheringAction;
        ICanTrade tradingAction;


        IHaveAnAction myAction;
        IHaveATarget targeter;
        private void Awake()
        {
            Initialization();
        }
        public ICanTrade Trade()
        {
            return tradingAction;
        }
        public ICanMove Move()
        {
            return movingAction;
        }
        public ICanCraft Craft()
        {
            return craftingAction;
        }
        public ICanGather Gatherer()
        {
            return gatheringAction;
        }
        public IHaveATarget Target()
        {
            return targeter;
        }
        public IAmAnInventory Inventory()
        {
            return inventory;
        }
        public IAmATrader Trader()
        {
            return trader;
        }
        public void Speak(string message, bool priority)
        {
            speakingAction.Saying(message, priority);
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
        public Vector3 GetWorldPosition()
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
            if (movingAction == null) return false;
            if (inventory == null) return false;
            if (trader == null) return false;
            if (gatheringAction == null) return false;
            if (craftingAction == null) return false;
            if (myAction == null) return false;
            if (targeter == null) return false;
            if (tradingAction == null) return false;
            return true;
        }
        private void Initialize()
        {
            inventory = GetComponent<IAmAnInventory>();
            trader = GetComponent<IAmATrader>();
            movingAction = GetComponent<ICanMove>();
            speakingAction = GetComponentInChildren<ICanSpeak>();
            gatheringAction = GetComponent<ICanGather>();
            craftingAction = GetComponent<ICanCraft>();
            myAction = GetComponent<IHaveAnAction>();
            targeter = GetComponent<IHaveATarget>();
            tradingAction = GetComponent<ICanTrade>();
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

