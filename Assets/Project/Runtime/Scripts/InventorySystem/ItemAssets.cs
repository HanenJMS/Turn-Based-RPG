using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {  get; private set; }
    [SerializeField] List<Item_Old> items = new List<Item_Old>();
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    Item_Old GetItemWorldObject(ItemType type)
    {
        Item_Old itemToFind = null;
        foreach(Item_Old item in items)
        {
            if(item.itemType == type)
                itemToFind = item;
        }
        return itemToFind;
    }
}
