using UnityEngine;

public abstract class ItemType : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    [TextArea(15, 20)]
    public string itemName;
    public string description;
    public int qualityValue;
}
