using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameUtilities.GridBuildingSystems
{
    public class Building : MonoBehaviour
    {
        [SerializeField] Transform buildingVisual;

        public void SetScale(Vector3 cellSize)
        {
            buildingVisual.localScale = cellSize;
        }
    }
}

