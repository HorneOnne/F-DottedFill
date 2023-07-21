using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DottedFill
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private GameObject normalPointPrefab;
        [SerializeField] private GameObject targetPointPrefab;
        [SerializeField] private float pointScaleFactor;

        private const int EMPTY = 0;
        private const int NORMAL = 1;
        private const int TARGET = 2;

        public LevelData levelData;
        public float gridSpacing = 0.2f;

        private void Start()
        {
            Camera.main.orthographicSize = levelData.orthographicCameraSize;
            CreateGrid();
        }

        private void CreateGrid()
        {
            int rows = levelData.arrayInt.GridSize.x; 
            int columns = levelData.arrayInt.GridSize.y;

            // Calculate the center position of the nodes.
            Vector3 centerOffset = new Vector3((columns - 1) * gridSpacing * 0.5f, -(rows - 1) * gridSpacing * 0.5f, 0f);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (levelData.arrayInt.GetCell(i,j) == NORMAL)
                    {
                        Vector3 position = new Vector3(i * gridSpacing, -j * gridSpacing, 0f) - centerOffset;

                        // Instantiate the objectPrefab at the specified position and default rotation.
                        Instantiate(normalPointPrefab, position, Quaternion.identity, this.transform);
                    }
                    else if (levelData.arrayInt.GetCell(i, j) == TARGET)
                    {
                        Vector3 position = new Vector3(i * gridSpacing, -j * gridSpacing, 0f) - centerOffset;

                        // Instantiate the objectPrefab at the specified position and default rotation.
                        Instantiate(targetPointPrefab, position, Quaternion.identity, this.transform);
                    }
                }
            }
        }
    }
}



