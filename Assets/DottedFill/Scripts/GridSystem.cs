using System.Collections.Generic;
using UnityEngine;

namespace DottedFill
{

    public class GridSystem : MonoBehaviour
    {
        public static GridSystem Instance { get; private set; }
        public static event System.Action OnStartAndTargetNodesSet;

        private const int EMPTY = 0;
        private const int NORMAL = 1;
        private const int TARGET = 2;

        [Header("References")]
        [SerializeField] private Node normalNodePrefab;
        [SerializeField] private Node targetNodePrefab;

        [Header("Data")]
        public LevelData levelData;

        [Header("Properties")]
        [SerializeField] private float pointScaleFactor;
        public float gridSpacing = 0.2f;

        [Header("Node")]
        [HideInInspector] public Node startNode;
        [HideInInspector] public Node finishNode;
        [Space(10)]
        [HideInInspector] public Node currentNode;

        [Header("Path")]
        public List<Node> currentNodePath = new List<Node>();

        // Cached
        private int numNodeNeedFill = 0;
        private Node[,] gridMap;

       



        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            OnStartAndTargetNodesSet += OnStartAndTargetNodeFilled;
        }

        private void OnDisable()
        {
            OnStartAndTargetNodesSet -= OnStartAndTargetNodeFilled;
        }

        private void Start()
        {
            Camera.main.orthographicSize = levelData.orthographicCameraSize;
            LoadLevel();
            CreateGrid();

        }


        private void LoadLevel()
        {
            int rows = levelData.arrayInt.GridSize.x;
            int columns = levelData.arrayInt.GridSize.y;
            gridMap = new Node[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int cellValue = levelData.arrayInt.GetCell(i, j);

                    if (cellValue == TARGET || cellValue == NORMAL)
                    {
                        numNodeNeedFill++;
                    }
                }
            }
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
                    Vector3 position = new Vector3(i * gridSpacing, -j * gridSpacing, 0f) - centerOffset;
                    Line line = LineManager.Instance.CreateLineObject();
                    if (levelData.arrayInt.GetCell(i, j) == NORMAL)
                    {
                        // Instantiate the objectPrefab at the specified position and default rotation.
                        gridMap[i, j] = Instantiate(normalNodePrefab, position, Quaternion.identity, this.transform);
                        gridMap[i, j].Setup(i, j, false, false, line);
                    }
                    else if (levelData.arrayInt.GetCell(i, j) == TARGET)
                    {
                        // Instantiate the objectPrefab at the specified position and default rotation.
                        gridMap[i, j] = Instantiate(targetNodePrefab, position, Quaternion.identity, this.transform);
                        gridMap[i, j].Setup(i, j, true, false, line);
                    }
                }
            }
        }

        public void SetCurrentNode(Node node)
        {
            currentNode = node;
            currentNodePath.Add(node);
            SetStartAndTargetNode(node);
            currentNode.Filled();
        }

        public void SetStartAndTargetNode(Node node)
        {
            if (node.isTargetNode == false) return;
            if (startNode == null)
            {
                Debug.Log(node == null);
                startNode = node;
            }
            else if (finishNode == null && node != startNode)
            {
                finishNode = node;
                OnStartAndTargetNodesSet?.Invoke();
            }
        }

        private void ResetFilledNode()
        {
            for (int i = 0; i < currentNodePath.Count; i++)
            {
                currentNodePath[i].ResetFillNode();
            }
        }

        private void OnStartAndTargetNodeFilled()
        {
            if (currentNodePath.Count == numNodeNeedFill)
            {              
                WinState();
            }
            else
            {
                ResetStateWhenWrongWay();
            }
        }
        private void WinState()
        {
            GamePlayManager.Instance.currentState = GamePlayManager.GameState.WIN;
        }

        private void ResetStateWhenWrongWay()
        {
            ResetFilledNode();
            LineManager.Instance.ClearAllLines();

            currentNode = null;
            startNode = null;
            finishNode = null;
            currentNodePath.Clear();
        }

        public void RemoveFromNode(Node node)
        {
            int startRevemoIndex = -1;
            for(int i = 0; i < currentNodePath.Count; i++)
            {
                if (currentNodePath[i] == node)
                {
                    startRevemoIndex = i;
                }
            }

            // Check if the start index is valid before removing
            if (startRevemoIndex >= 0 && startRevemoIndex < currentNodePath.Count)
            {
                int countToRemove = currentNodePath.Count - startRevemoIndex;

                for (int i = 0; i < countToRemove; i++)
                {
                    currentNodePath[startRevemoIndex].line.Clear();
                    currentNodePath[startRevemoIndex].ResetFillNode();
                    currentNodePath.RemoveAt(startRevemoIndex); // Remove the element at the startIndex each time
                }

            }
        }
    }
}



