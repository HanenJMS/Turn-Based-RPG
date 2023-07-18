using TMPro;
using UnityEngine;
namespace RPGSandBox.GameUtilities.GridCore
{
    public class GridDebugObject : MonoBehaviour
    {
        GridObject grid;
        [SerializeField] TextMeshPro textMeshPro;
        private void Awake()
        {
            textMeshPro = GetComponentInChildren<TextMeshPro>();
        }
        public void SetGridObject(GridObject gridObject)
        {
            grid = gridObject;
        }
        private void Update()
        {
            textMeshPro.text = grid.ToString();

        }
    }
}
