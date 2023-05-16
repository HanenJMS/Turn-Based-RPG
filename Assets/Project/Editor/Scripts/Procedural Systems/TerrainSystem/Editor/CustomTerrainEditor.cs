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
    SerializedProperty customTerrainPerlinScaleX;
    SerializedProperty customTerrainPerlinScaleY;
    SerializedProperty customTerrainPerlinScaleOffsetX;
    SerializedProperty customTerrainPerlinScaleOffsetY;
    //fold outs -------------------
    bool showRandom = false;
    bool showLoadHeights = false;
    bool showPerlin = false;
    private void OnEnable()
    {
        //random
        customTerrainRandomHeightRange = serializedObject.FindProperty("randomHeightRange");

        //heightmap from imaging
        customTerrainHeightMapScale = serializedObject.FindProperty("heightMapImage");
        customTerrainheightMapImage = serializedObject.FindProperty("heightMapScale");

        //heighmap from perlin
        customTerrainPerlinScaleX = serializedObject.FindProperty("perlinScaleX");
        customTerrainPerlinScaleY = serializedObject.FindProperty("perlinScaleY");
        //perlin offset
        customTerrainPerlinScaleOffsetX = serializedObject.FindProperty("perlinScaleOffsetX");
        customTerrainPerlinScaleOffsetY = serializedObject.FindProperty("perlinScaleOffsetY");


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
        HandlePerlinTerrainGeneration(terrain);
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
        showLoadHeights = EditorGUILayout.Foldout(showLoadHeights, "Load terrain height texture");

        if (showLoadHeights)
        {
            GUILayout.Label("Generate height map texture", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(customTerrainHeightMapScale);
            EditorGUILayout.PropertyField(customTerrainheightMapImage);
            if (GUILayout.Button("Height Map Texture from image"))
            {
                terrain.LoadHeightMapTexture();
            }
        }
    }
    private void HandlePerlinTerrainGeneration(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showPerlin = EditorGUILayout.Foldout(showPerlin, "Use Perlin to Generate Terrain");
        if (showPerlin)
        {
            GUILayout.Label("Using Perlin function to Generate Terrain", EditorStyles.boldLabel);
            EditorGUILayout.Slider(customTerrainPerlinScaleX, 0,1, new GUIContent("X Scale"));
            EditorGUILayout.Slider(customTerrainPerlinScaleY, 0, 1, new GUIContent("Y Scale"));
            EditorGUILayout.IntSlider(customTerrainPerlinScaleOffsetX, 0, 10000, new GUIContent("X Offset"));
            EditorGUILayout.IntSlider(customTerrainPerlinScaleOffsetY, 0, 10000, new GUIContent("Y Offset"));
            if (GUILayout.Button("Use PerlinNoise generator"))
            {
                terrain.PerlinTerrainGenerator();
            }
        }
    }
    private void HandleResetTerrain(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Reset Height to Zero"))
        {
            terrain.GenerateTerrainHeight(true);
        }
    }
}
