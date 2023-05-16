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
    }
}

