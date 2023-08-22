using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

public class CraftingFactory : MonoBehaviour, IAmACraftsmanBuilding
{
    List<IAmACraftingJob> craftingJobs = new List<IAmACraftingJob>();
    IAmAnInventory inventory;
    IAmATrader merchant;
    private void Awake()
    {
        inventory = GetComponent<IAmAnInventory>();
    }

    public string DescriptionContent()
    {
        return "Crafting Factory";
    }

    public string DescriptionHeader()
    {
        return "Building for Craftsmen to collect together to craft things. They hold job listings for demand of the factory.";
    }

    public bool CanInteract(IAmInteractable interact)
    {
        return false;
    }

    public string InteractableName()
    {
        return "Crafting Building";
    }

    public Vector3 MyPosition()
    {
        return this.transform.position;
    }

    public IAmAnInventory GetMyInventory()
    {
        return inventory;
    }
}
