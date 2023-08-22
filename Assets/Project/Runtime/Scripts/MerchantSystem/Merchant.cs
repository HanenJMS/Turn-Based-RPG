using RPGSandBox.InterfaceSystem;
using RPGSandBox.InventorySystem;
using RPGSandBox.InventorySystem.Item;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace RPGSandBox.MerchantSystem
{
    public class Merchant : MonoBehaviour, IAmAMerchant
    {
        readonly Dictionary<string, int> buyWares = new Dictionary<string, int>();
        ReadOnlyDictionary <string, int> sellWares = new Dictionary<string, int>();








        public void Sucker(IAmAUnit target)
        {
            
        }
    }
}

