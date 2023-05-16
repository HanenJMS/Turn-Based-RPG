using HanensGameLab.Utilities.ProceduralSystems.TerrainSystem;
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]
public class CustomTerrainEditor : Editor
{
    //properties ------------------
    SerializedProperty customTerrainRandomHeightRange;
    SerializedProperty customTerrainHeightMapScale;
    SerializedProperty customTerrainheightMapImage;

    //fold outs -------------------
    bool showRandom = false;
    bool showLoadHeights = false;
    private void OnEnable()
    {
        customTerrainRandomHeightRange = serializedObject.FindProperty("randomHeightRange");
        customTerrainHeightMapScale = serializedObject.FindProperty("heightMapImage");
        customTerrainheightMapImage = serializedObject.FindProperty("heightMapScale");
        if (customTerrainRandomHeightRange == null)
        {
            Debug.Log($"{this.name} is missing a serializedProperty. FindProperty() found nothing. Maybe don't use strings?");
        }
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CustomTerrain terrain = (CustomTerrain)target;
        HandleRandomTerrainHeightGeneration(terrain);
        HandleLoadingTerrainHeight(terrain);
        HandleResetTerrain(terrain);

        serializedObject.ApplyModifiedProperties();
    }
    private void HandleRandomTerrainHeightGeneration(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showRandom = EditorGUILayout.Foldout(showRandom, "Random Height Generator");
        
        if (showRandom)
        {
            GUILayout.Label("Set Heights Between Random Values", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(customTerrainRandomHeightRange);
            if (GUILayout.Button("Random Heights"))
            {
                terrain.GenerateTerrainHeight(false);
            }
        }
    }
    private void HandleLoadingTerrainHeight(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showLoadHeights = EditorGUILayout.Foldout(showLoadHeights, "Load Heights");
        if (showLoadHeights)
        { 
            GUILayout.Label("Load Terrain Heights From Texture", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(customTerrainHeightMapScale);
            EditorGUILayout.PropertyField(customTerrainheightMapImage);
            if (GUILayout.Button("Load Texture"))
            {
                terrain.LoadHeightMapTexture();
            }
        }
    }
    private static void HandleResetTerrain(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Reset Height to Zero"))
        {
            terrain.GenerateTerrainHeight(true);
        }
    }
}
