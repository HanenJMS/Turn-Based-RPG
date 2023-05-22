using EditorGUITable;
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
    SerializedProperty customTerrainPerlinOctave;
    SerializedProperty customTerrainPerlinPersistence;
    SerializedProperty customTerrainPerlinHeightScale;
    SerializedProperty customTerrainisTerrainAdded;

    GUITableState perlinParameterTable;
    SerializedProperty customTerrainperlinParameterList;

    SerializedProperty customTerrain_voronoiMountainPeakAmount;
    SerializedProperty customTerrain_fallOffset;
    SerializedProperty customTerrain_dropOffset;
    SerializedProperty customTerrain_minHeight;
    SerializedProperty customTerrain_maxHeight;
    //fold outs -------------------
    bool showRandom = false;
    bool showLoadHeights = false;
    bool showPerlin = false;
    bool showPerlinTable = false;
    bool showVoronoi = false;
    bool showVoronoiSet = false;
    private void OnEnable()
    {
        InitializeSerializedTerrainObject();

        if (customTerrainRandomHeightRange == null)
        {
            Debug.Log($"{this.name} is missing a serializedProperty. FindProperty() found nothing. Maybe don't use strings?");
        }
    }

    private void InitializeSerializedTerrainObject()
    {
        //random
        customTerrainRandomHeightRange = serializedObject.FindProperty("randomHeightRange");

        //heightmap from imaging
        customTerrainHeightMapScale = serializedObject.FindProperty("heightMapImage");
        customTerrainheightMapImage = serializedObject.FindProperty("heightMapScale");

        //heighmap from perlin
        customTerrainPerlinScaleX = serializedObject.FindProperty("perlinScaleX");
        customTerrainPerlinScaleY = serializedObject.FindProperty("perlinScaleY");
        customTerrainPerlinOctave = serializedObject.FindProperty("perlinOctaves");
        customTerrainPerlinPersistence = serializedObject.FindProperty("perlinPersistence");
        customTerrainPerlinHeightScale = serializedObject.FindProperty("perlinHeightScale");
        //perlin offset
        customTerrainPerlinScaleOffsetX = serializedObject.FindProperty("perlinScaleOffsetX");
        customTerrainPerlinScaleOffsetY = serializedObject.FindProperty("perlinScaleOffsetY");

        //controls
        customTerrainisTerrainAdded = serializedObject.FindProperty("isTerrainAdded");

        //Voronoi Configuration
        customTerrain_voronoiMountainPeakAmount = serializedObject.FindProperty("voronoiMountainPeakAmount");
        customTerrain_fallOffset = serializedObject.FindProperty("fallOffset");
        customTerrain_dropOffset = serializedObject.FindProperty("dropOffset");
        customTerrain_minHeight = serializedObject.FindProperty("minHeight");
        customTerrain_maxHeight = serializedObject.FindProperty("maxHeight");
        //perlin table
        perlinParameterTable = new GUITableState("perlinParameterTable");
        customTerrainperlinParameterList = serializedObject.FindProperty("perlinParameterList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CustomTerrain terrain = (CustomTerrain)target;
        EditorGUILayout.PropertyField(customTerrainisTerrainAdded);

        HandleTerrainHeightGenerationRandom(terrain);
        HandleTerrainHeightGenerationTexture(terrain);
        HandleTerrainHeightGenerationPerlinSingle(terrain);
        HandleTerrainHeightGenerationPerlinSet(terrain);
        HandleTerrainHeightGenerationVoronoi(terrain);
        HandleTerrainHeightGenerationReset(terrain);

        serializedObject.ApplyModifiedProperties();
    }



    private void HandleTerrainHeightGenerationRandom(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showRandom = EditorGUILayout.Foldout(showRandom, "Random Height Generator");

        if (showRandom)
        {
            GUILayout.Label("Set Heights Between Random Values", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(customTerrainRandomHeightRange);
            if (GUILayout.Button("Random Heights"))
            {
                terrain.TerrainHeightGenerationRandom(false);
            }
        }
    }
    private void HandleTerrainHeightGenerationTexture(CustomTerrain terrain)
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
                terrain.TerrainHeightGenerationTexture();
            }
        }
    }
    private void HandleTerrainHeightGenerationPerlinSingle(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showPerlin = EditorGUILayout.Foldout(showPerlin, "Use Perlin to Generate Terrain");
        if (showPerlin)
        {
            GUILayout.Label("Using Perlin function to Generate Terrain", EditorStyles.boldLabel);
           
            EditorGUILayout.Slider(customTerrainPerlinScaleX, 0, 1, new GUIContent("X Scale"));
            EditorGUILayout.Slider(customTerrainPerlinScaleY, 0, 1, new GUIContent("Y Scale"));
            EditorGUILayout.IntSlider(customTerrainPerlinScaleOffsetX, 0, 10000, new GUIContent("X Offset"));
            EditorGUILayout.IntSlider(customTerrainPerlinScaleOffsetY, 0, 10000, new GUIContent("Y Offset"));
            EditorGUILayout.IntSlider(customTerrainPerlinOctave, 1, 10, new GUIContent("Octaves"));
            EditorGUILayout.Slider(customTerrainPerlinPersistence, 0.1f, 10, new GUIContent("Persistence"));
            EditorGUILayout.Slider(customTerrainPerlinHeightScale, 0, 1, new GUIContent("Heigtmap scale"));

            if (GUILayout.Button("Use PerlinNoise generator"))
            {
                terrain.TerrainHeightGenerationPerlinSingle();
            }
        }
    }
    private void HandleTerrainHeightGenerationPerlinSet(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showPerlinTable = EditorGUILayout.Foldout(showPerlinTable, "Perlin Height Map Table");

        if (showPerlinTable)
        {
            GUILayout.Label("Perlin Noise Table", EditorStyles.boldLabel);
            perlinParameterTable = GUITableLayout.DrawTable(perlinParameterTable, serializedObject.FindProperty("perlinParameterList"));
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+"))
            {
                terrain.AddNewPerlin();
            }
            if (GUILayout.Button("-"))
            {
                terrain.RemovePerlin();
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Apply Multiple Perlin"))
            {
                terrain.TerrainHeightGenerationPerlinSet();
            }
        }
    }
    private void HandleTerrainHeightGenerationVoronoi(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showVoronoi = EditorGUILayout.Foldout(showVoronoi, "Terrain Height Generation Voronoi");
        if(showVoronoi)
        {
            GUILayout.Label("Using Voronoi function to Generate Terrain", EditorStyles.boldLabel);
            EditorGUILayout.IntSlider(customTerrain_voronoiMountainPeakAmount, 0, 10, new GUIContent("number of mountains"));
            EditorGUILayout.Slider(customTerrain_fallOffset, 0, 10, new GUIContent("Fall off value for side of mountain"));
            EditorGUILayout.Slider(customTerrain_dropOffset, 0, 10, new GUIContent("Mountain slope drop off value"));
            EditorGUILayout.Slider(customTerrain_minHeight, 0, 1, new GUIContent("minHeight of each mountain"));
            EditorGUILayout.Slider(customTerrain_maxHeight, 0, 1, new GUIContent("max height of each mountain"));
            if (GUILayout.Button("Generate Terrain Voronoi (mountains)"))
            {
                terrain.GenerateTerrainHeightMtVoronoi();
            }
        }
    }

    private void HandleTerrainHeightGenerationReset(CustomTerrain terrain)
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Reset Height to Zero"))
        {
            terrain.TerrainHeightGenerationRandom(true);
        }
    }
}
