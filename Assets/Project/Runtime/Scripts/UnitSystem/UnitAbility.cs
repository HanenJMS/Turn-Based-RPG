using RPGSandBox.InterfaceSystem;
using UnityEngine;

public class UnitAbility : MonoBehaviour, IHaveAbilities
{
    [SerializeField] float sinceLastAbilityUsed = float.MaxValue;

    public void Using(IAmAnAbility ability, IAmInteractable target)
    {
        ability.UsingOn(target);
    }
}
