using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HanensGameLab.Utilities.ProceduralSystems.TerrainSystem
{
    [ExecuteInEditMode]
    public class CustomTerrain : MonoBehaviour
    {
        [SerializeField] List<string> terrainTags = new List<string>();
        [SerializeField] Vector2 randomHeightRange = new Vector2(0, 0.1f);

        [SerializeField] bool isTerrainAdded = false;

        //does this break MVC architecture? what are the responsibilities of these properties?
        [SerializeField] Texture2D heightMapImage;
        [SerializeField] Vector3 heightMapScale = new Vector3(1, 1, 1);

        //Perlin Noise
        [SerializeField] float perlinScaleX = 0.01f;
        [SerializeField] float perlinScaleY = 0.01f;
        [SerializeField] int perlinScaleOffsetX = 0;
        [SerializeField] int perlinScaleOffsetY = 0;
        [SerializeField] int perlinOctaves = 3;
        [SerializeField] float perlinPersistence = 8;
        [SerializeField] float perlinHeightScale = 0.0f;

        //Voronoi Configuration
        [SerializeField] int voronoiMountainPeakAmount = 0;
        [SerializeField] float fallOffset = 0.2f;
        [SerializeField] float dropOffset = 0.6f;
        [SerializeField] float minHeight = 0f;
        [SerializeField] float maxHeight = 500f;

        //Perlin Object
        [System.Serializable]
        public class PerlinParameters
        {
            public float perlinScaleX = 0.01f;
            public float perlinScaleY = 0.01f;
            public int perlinScaleOffsetX = 0;
            public int perlinScaleOffsetY = 0;
            public int perlinOctaves = 3;
            public float perlinPersistence = 8;
            public float perlinHeightScale = 0.0f;
            public bool remove = true;

        }

        public List<PerlinParameters> perlinParameterList = new List<PerlinParameters>()
        {
            new PerlinParameters()
        };

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



        public void TerrainHeightGenerationRandom(bool ResetHeightMap)
        {
            float[,] terrainHeightMap = GetHeightMap();
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
        public void TerrainHeightGenerationTexture()
        {
            float[,] terrainHeightMap = GetHeightMap();
            for (int x = 0; x < terrainData.heightmapResolution; x++)
            {
                for (int z = 0; z < terrainData.heightmapResolution; z++)
                {
                    terrainHeightMap[x, z] = heightMapImage.GetPixel((int)(x * heightMapScale.x), (int)(z * heightMapScale.z)).grayscale * heightMapScale.y;
                }
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }
        public void TerrainHeightGenerationPerlinSingle()
        {
            float[,] terrainHeightMap = GetHeightMap();
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                for (int x = 0; x < terrainData.heightmapResolution; x++)
                {
                    terrainHeightMap[y, x] = UseUtilsFractalBrownianMotionAlgorithm(x, y);
                }
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }
        public void TerrainHeightGenerationPerlinSet()
        {
            float[,] terrainHeightMap = GetHeightMap();
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                for (int x = 0; x < terrainData.heightmapResolution; x++)
                {
                    foreach (PerlinParameters p in perlinParameterList)
                    {
                        terrainHeightMap[y, x] += UseUtilsFractalBrownianMotionAlgorithm(x, y);
                    }
                }
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }
        public void GenerateTerrainHeightMtVoronoi()
        {
            float[,] terrainHeightMap = GetHeightMap();

            for (int i = 0; i < voronoiMountainPeakAmount; i++)
            {
                GenerateMtVoronoi(terrainHeightMap);
            }
            terrainData.SetHeights(0, 0, terrainHeightMap);
        }

        private void GenerateMtVoronoi(float[,] terrainHeightMap)
        {
            Vector3 peak = Utils.Voronoi(terrainData.heightmapResolution, minHeight, maxHeight);

            terrainHeightMap[(int)peak.x, (int)peak.z] = peak.y;

            Vector2 peakLocation = new Vector2(peak.x, peak.z);
            float maxDistance = Vector2.Distance(new Vector2(0, 0),
                                                 new Vector2(terrainData.heightmapResolution, terrainData.heightmapResolution));

            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                for (int x = 0; x < terrainData.heightmapResolution; x++)
                {
                    if (!(x == peak.x && y == peak.z))
                    {
                        float distanceToPeak = Vector2.Distance(peakLocation, new Vector2(x, y)) / maxDistance;
                        float h = peak.y - distanceToPeak * fallOffset -
                                Mathf.Pow(distanceToPeak, dropOffset);

                        if (terrainHeightMap[x, y] < h)
                        {
                            terrainHeightMap[x, y] = h;
                        }
                    }
                }
            }
        }

        public void AddNewPerlin()
        {
            perlinParameterList.Add(new PerlinParameters());
        }
        public void RemovePerlin()
        {
            List<PerlinParameters> newPerlinPerimeterList = new List<PerlinParameters>();
            foreach (PerlinParameters p in perlinParameterList)
            {
                if (!p.remove) newPerlinPerimeterList.Add(p);
            }
            if (newPerlinPerimeterList.Count == 0) newPerlinPerimeterList.Add(perlinParameterList[0]);
            perlinParameterList = newPerlinPerimeterList;
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
        private float[,] GetHeightMap()
        {
            if (isTerrainAdded)
            {
                return terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
            }
            return new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        }
        private float UseUtilsFractalBrownianMotionAlgorithm(int x, int y)
        {
            return Utils.FBM((x + perlinScaleOffsetX) * perlinScaleX,
                             (y + perlinScaleOffsetY) * perlinScaleY,
                              perlinOctaves, perlinPersistence) * perlinHeightScale;

        }
    }
}

