using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.MerchantSystem
{
    public class MerchantTrader : MonoBehaviour, IAmATrader
    {
        readonly Dictionary<string, int> buyWares = new Dictionary<string, int>();
        readonly Dictionary<string, int> sellWares = new Dictionary<string, int>();


    }
}

