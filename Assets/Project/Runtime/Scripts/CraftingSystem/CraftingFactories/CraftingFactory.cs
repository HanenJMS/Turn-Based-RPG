using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

public class CraftingFactory : MonoBehaviour, IAmACraftsmanBuilding
{
    List<IAmACraftingJob> craftingJobs = new List<IAmACraftingJob>();
    IHaveAnInventory inventory;
    IAmAMerchant merchant;
    private void Awake()
    {
        inventory = GetComponent<IHaveAnInventory>();
    }
    
    public string DescriptionContent()
    {
        return "Crafting Factory";
    }

    public string DescriptionHeader()
    {
        return "Building for Craftsmen to collect together to craft things. They hold job listings for demand of the factory.";
    }

    public void Interact(IAmInteractable interact)
    {
        
    }

    public string InteractableName()
    {
        return "Crafting Building";
    }

    public Vector3 MyPosition()
    {
        return this.transform.position;
    }


}
