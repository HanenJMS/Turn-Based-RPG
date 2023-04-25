using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {  get; private set; }
    [SerializeField] List<Item> items = new List<Item>();
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    Item GetItemWorldObject(ItemType type)
    {
        Item itemToFind = null;
        foreach(Item item in items)
        {
            if(item.itemType == type)
                itemToFind = item;
        }
        return itemToFind;
    }
}
