using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using TreeEditor;

namespace HanensGameLab.Utilities.ProceduralSystems.TerrainSystem
{
    [ExecuteInEditMode]
    public class CustomTerrain : MonoBehaviour
    {
        [SerializeField] List<string> terrainTags = new List<string>();
        [SerializeField] Vector2 randomHeightRange = new Vector2(0, 0.1f);


        //does this break MVC architecture? what are the responsibilities of these properties?
        [SerializeField] Texture2D heightMapImage;
        [SerializeField] Vector3 heightMapScale = new Vector3(1,1,1);

        //Perlin Noise
        [SerializeField] float perlinScaleX = 0.01f;
        [SerializeField] float perlinScaleY = 0.01f;

        [SerializeField] Terrain terrain;
        [SerializeField] TerrainData terrainData;
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
        private void OnEnable()
        {
            Debug.Log("Initializing Terrain Data");
            terrain = this.GetComponent<Terrain>();
            terrainData = terrain.terrainData;
            
        }
        private void PerlinFunction()
        {
            throw new System.NotImplementedException();
        }
        public void GenerateTerrainHeight(bool ResetHeightMap)
        {
            float[,] terrainHeightMap = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
            for (int x = 0; x < terrainData.heightmapResolution; x++)
            {
                for (int z = 0; z < terrainData.heightmapResolution; z++)
                {
                    if (ResetHeightMap) terrainHeightMap[x, z] = 0;
                    else
                    {
                        terrainHeightMap[x, z] += Random.Range(randomHeightRange.x, randomHeightRange.y);
                    }
                }
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }



        public void LoadHeightMapTexture()
        {
            float[,] terrainHeightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];        
            for (int x = 0; x < terrainData.heightmapResolution; x++)
            {
                for (int z = 0; z < terrainData.heightmapResolution; z++)
                {
                    terrainHeightMap[x, z] = heightMapImage.GetPixel((int)(x * heightMapScale.x), (int)(z * heightMapScale.z)).grayscale * heightMapScale.y;
                }
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }
        //void RandomTerrain(float[,] terrainHeightMap)
        //{
        //    for(int x = 0; x < terrainData.heightmapResolution; x++)
        //    {
        //        for(int z = 0; z < terrainData.heightmapResolution; z++)
        //        {
        //            terrainHeightMap[x, z] += Random.Range(randomHeightRange.x, randomHeightRange.y); 
        //        }
        //    }
        //}
        //void ResetTerrain(float[,] terrainHeightMap)
        //{
        //    for (int x = 0; x < terrainData.heightmapResolution; x++)
        //    {
        //        for (int z = 0; z < terrainData.heightmapResolution; z++)
        //        {
        //            terrainHeightMap[x, z] = 0;
        //        }
        //    }
        //}
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

