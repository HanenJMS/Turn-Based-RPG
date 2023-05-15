using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace HanensGameLab.Utilities.ProceduralSystems.TerrainSystem
{
    [ExecuteInEditMode]
    public class CustomTerrain : MonoBehaviour
    {
        [SerializeField] List<string> terrainTags = new List<string>();
        private void Awake()
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

            SerializedProperty editorInspectorTagProperty = tagManager.FindProperty("tags");

            AddTag(editorInspectorTagProperty, "Terrain");
            AddTag(editorInspectorTagProperty, "Cloud");
            AddTag(editorInspectorTagProperty, "Shore");

            tagManager.ApplyModifiedProperties();

            //foreach (string tagName in terrainTags)
            //{
            //    AddTag(editorInspectorTagProperty, tagName);
            //}

            this.gameObject.tag = "Terrain";
        }

        private void AddTag(SerializedProperty editorInspectorTagProperty, string newTag)
        {
            for (int i = 0; i < editorInspectorTagProperty.arraySize; i++)
            {
                string inspectorTagPropertyString = editorInspectorTagProperty.GetArrayElementAtIndex(i).stringValue;
                if (inspectorTagPropertyString.Equals(newTag)) return;
            }

            editorInspectorTagProperty.InsertArrayElementAtIndex(0);
            editorInspectorTagProperty.GetArrayElementAtIndex(0).stringValue = newTag;
        }
    }
}

