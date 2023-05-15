using RPGSandBox.GameUtilities.GridCore;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUtilities.GridBuildingSystems
{
    public class GridBuildingSystem : MonoBehaviour
    {
        Dictionary<GridPosition, GridObject> currentGridSystem;
        [SerializeField] LayerMask MousePlaneLayerMask;
        [SerializeField] PlaceObjectTypeSO placedObjectTypeSO;
        private void Start()
        {
            currentGridSystem = LevelGrid.Instance.GetGridObjects();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = MouseWorld.GetMousePosition();
                GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(mousePosition);
                Vector3 buildingPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
                if (buildingPosition == null) { return; }
                if (currentGridSystem[gridPosition].HasObject()) return;
                Transform buildingGameObject = Instantiate(placedObjectTypeSO.prefab, buildingPosition, Quaternion.identity);
                Building building = buildingGameObject.GetComponent<Building>();
                if (building == null) { return; }

                float cellSize = (LevelGrid.Instance.GetCellSize() / 10) * placedObjectTypeSO.width;
                building.SetScale(Vector3.one * cellSize);
                currentGridSystem[gridPosition].AddObject(building.gameObject);
            }
        }
    }
}
