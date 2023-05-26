using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    Item_Old item;
    public static ItemWorld SpawnItemWorld(Item_Old item, Vector3 position)
    {
        Transform transform = Instantiate(item.transform, position, Quaternion.identity);
        ItemWorld worldItem = transform.GetComponent<ItemWorld>();
        worldItem.SetItem(item);
        return worldItem;
    }

    void SetItem(Item_Old item)
    {
        this.item = item;

    }
}
