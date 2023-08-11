using UnityEngine;

namespace HanensGameLab.Utilities
{
    public static class Utils
    {
        public static float FBM(float x, float y, int octave, float persistence)
        {
            float total = 0;
            float frequency = 1;
            float amplitude = 1;
            float maxValue = 0;
            for (int i = 0; i < octave; i++)
            {
                total += Mathf.PerlinNoise(x * frequency, y * frequency * amplitude);
                maxValue += amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }
            return total / maxValue;
        }
        public static Vector3 Voronoi(int heightMapResolution, float minHeight, float maxHeight)
        {
            return new Vector3(UnityEngine.Random.Range(0, heightMapResolution - 1), // x coordinate
                               UnityEngine.Random.Range(minHeight, maxHeight),  // y coordinate
                               UnityEngine.Random.Range(0, heightMapResolution - 1));// z coordinate
        }
    }
}

