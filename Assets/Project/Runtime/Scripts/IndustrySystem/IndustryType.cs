using RPGSandBox.InterfaceSystem;
using UnityEngine;
namespace RPGSandBox.IndustrySystem
{
    [CreateAssetMenu(fileName = "IndustryType", menuName = "IndustrySystem/IndustryType/new Industry")]
    public class IndustryType : ScriptableObject, IAmAnIndustry
    {
        public string IndustryName;
    }
}

