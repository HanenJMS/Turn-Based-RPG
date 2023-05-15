using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.GameUtilities.GridCore
{
    public class GridObject
    {
        GridSystem gridSystem;
        GridPosition gridPosition;
        GridPosition gridPositionAbove, gridPositionLeft, gridPositionRight, gridPositionBelow;
        List<GridPosition> AdjacentGrids = new List<GridPosition>();
        List<GameObject> gameObjects;
        int index = 0;
        public GridObject(GridSystem gridSystem, GridPosition gridPosition, int gridMaxWidth, int gridMaxHeight)
        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
            gridPositionAbove = new GridPosition(gridPosition.x, gridPosition.z + 1);
            gridPositionBelow = new GridPosition(gridPosition.x, gridPosition.z - 1);
            gridPositionLeft = new GridPosition(gridPosition.x - 1, gridPosition.z);
            gridPositionRight = new GridPosition(gridPosition.x + 1, gridPosition.z);
            if (gridPositionBelow.z >= 0)
                AdjacentGrids.Add(gridPositionBelow);
            if (gridPositionLeft.x >= 0)
                AdjacentGrids.Add(gridPositionLeft);
            if (gridPositionAbove.z < gridMaxWidth)
                AdjacentGrids.Add(gridPositionAbove);
            if (gridPositionRight.x < gridMaxHeight)
                AdjacentGrids.Add(gridPositionRight);

            gameObjects = new List<GameObject>();
        }

        public void AddObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        public List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (gameObjects.Contains(gameObject))
            {
                gameObjects.Remove(gameObject);
            }
        }
        public bool HasObject()
        {
            return gameObjects.Count > 0;
        }
        public List<GridPosition> GetAdjacentGridPosition()
        {

            return AdjacentGrids;
        }
        public override string ToString()
        {
            string gameObjectNames = "";
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectNames += $"{gameObject}\n";
            }
            return gridPosition.ToString() + $"\n{gameObjectNames}";
        }

        internal GridPosition GetNextGridPosition()
        {
            GridPosition gridNextPosition = AdjacentGrids[index];
            index++;
            if (index == AdjacentGrids.Count) index = 0;
            return gridNextPosition;
        }
        internal GridPosition GetRandomNextPosition()
        {
            int i = UnityEngine.Random.Range(0, AdjacentGrids.Count);
            GridPosition gridNextPosition = AdjacentGrids[i];
            return gridNextPosition;
        }
    }
}
