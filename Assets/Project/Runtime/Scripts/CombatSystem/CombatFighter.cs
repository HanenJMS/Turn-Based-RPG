using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.CombatSystem
{
    public class CombatFighter : MonoBehaviour
    {
        object combatTarget;
        object healthComponent;
        object manaComponent;

        bool CanExecute(object skill)
        {
            return false;
        }
        void ExecuteSkill(object target, object skill)
        {

        }
    }
}


