using RPGSandBox.GameUtilities.GridCore;
using RPGSandBox.InterfaceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RPGSandBox.UnitSystem
{
    public class Unit : MonoBehaviour, IAmAUnit
    {
        [SerializeField] Inventory inventory;
        bool isSelected = false;
        UnitMover mover;

        private void Awake()
        {
            inventory = GetComponent<Inventory>();
            mover = GetComponentInChildren<UnitMover>();
        }

        public void MoveToDestination(Vector3 destination)
        {
            if (mover == null) mover = GetComponentInChildren<UnitMover>();
            mover.MoveToDestination(destination);
        }

        public bool IsSelected()
        {
            return isSelected;
        }

        public void OnSelected()
        {
            isSelected = !isSelected;
        }
    }
}

