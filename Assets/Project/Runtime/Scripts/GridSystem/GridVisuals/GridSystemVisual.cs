using RPGSandBox.GameUtilities.GridCore;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandBox.GameUtilities.GridSystemVisuals
{
    public class GridSystemVisual : MonoBehaviour
    {
        public static GridSystemVisual Instance { get; private set; }
        Dictionary<GridPosition, GridSystemVisualSingle> gridVisualSystem = new Dictionary<GridPosition, GridSystemVisualSingle>();
        [SerializeField] Transform gridSystemVisualSinglePrefab;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            foreach (KeyValuePair<GridPosition, GridObject> obj in LevelGrid.Instance.GetGridObjects())
            {
                Transform gridSystemVisualSingleTransform = Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(obj.Key), Quaternion.identity, this.transform);
                GridSystemVisualSingle gridSystemVisualSingle = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
                gridVisualSystem.Add(obj.Key, gridSystemVisualSingle);
                gridSystemVisualSingle.Hide();
            }
        }
        private void Update()
        {
            UpdateGridVisual();
        }
        public void HideAllGridPositions()
        {
            foreach (KeyValuePair<GridPosition, GridSystemVisualSingle> obj in gridVisualSystem)
            {
                obj.Value.Hide();
            }
        }
        public void ShowGridPositionList(List<GridPosition> gridPositioList)
        {
            foreach (GridPosition grid in gridPositioList)
            {
                if (gridVisualSystem.ContainsKey(grid))
                {
                    gridVisualSystem[grid].Show();
                }
            }
        }
        public void UpdateGridVisual()
        {
            HideAllGridPositions();
            if (UnitActionSystem_Old.Instance.GetCurrentAction() == null) return;
            List<GridPosition> gridPositions = UnitActionSystem_Old.Instance.GetCurrentAction().GetValidGridPositionList();
            if (gridPositions == null) return;
            ShowGridPositionList(gridPositions);
        }
    }
}
