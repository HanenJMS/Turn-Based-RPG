using RPGSandBox.InterfaceSystem;
using System.Collections.Generic;
using UnityEngine;

public class CraftsmanBuilding : MonoBehaviour, IAmACraftsmanBuilding
{
    List<IAmACraftingJob> craftingJobs = new List<IAmACraftingJob>();
    public string DescriptionContent()
    {
        return "";
    }

    public string DescriptionHeader()
    {
        return "";
    }

    public void Interact(IAmInteractable interact)
    {
        
    }

    public string InteractableName()
    {
        return "";
    }

    public Vector3 MyPosition()
    {
        return this.transform.position;
    }
}
