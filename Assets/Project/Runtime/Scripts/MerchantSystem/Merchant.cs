using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.MerchantSystem
{
    public class Merchant : MonoBehaviour, IAmAMerchant
    {
        List<InventorySlot> wares = new List<InventorySlot>();
        Dictionary<IAmAMerchant, Trade> pendingTrades = new Dictionary<IAmAMerchant, Trade>();
        public void Sucker(IAmAUnit target)
        {
            
        }
    }
}

