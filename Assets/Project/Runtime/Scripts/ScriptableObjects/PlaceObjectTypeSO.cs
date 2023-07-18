using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlaceObjectTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public Transform visual;
    public int width;
    public int height;
}
