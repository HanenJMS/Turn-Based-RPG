using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public Sprite sprite;
    [TextArea(15, 20)]
    public string description;
    public int qualityValue;
}
