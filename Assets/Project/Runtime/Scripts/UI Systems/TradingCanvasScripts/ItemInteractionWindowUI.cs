using RPGSandBox.Controller;
using RPGSandBox.InterfaceSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RPGSandBox.GameUI
{
    public class ItemInteractionWindowUI : MonoBehaviour, IAmAGameUI
    {
        [SerializeField]Slider slider;
        InventorySlotUI inventorySlot;
        int count = 0;
        private void Awake()
        {
            inventorySlot = GetComponentInChildren<InventorySlotUI>();
            slider = GetComponentInChildren<Slider>();
        }
        private void Start()
        {
            InterfaceControllerSystem.Instance.OnActivateItemInteractionWindowUI += Activate;
        }
        public void Activate(IAmAnInventorySlot inventorySlot)
        {
            this.inventorySlot.SetItemSlotUI(inventorySlot);
            slider.value = 0;
            count = inventorySlot.Quantity();
            ActivateUI();
        }

        public void Update()
        {
            inventorySlot.SetCounterText($"{slider.value}/{count}");
        }

        public void ActivateUI()
        {
            this.gameObject.SetActive(true);
        }

        public void DeActivateUI()
        {
            this.gameObject.SetActive(false);
        }

        public void ClearUI()
        {
            
        }

        public void UpdateUI()
        {
            
        }
    }
}

