using UnityEngine;
using System.Collections.Generic;

namespace DottedFill
{
    public class LineManager : MonoBehaviour
    {
        public static LineManager Instance { get; private set; }

        [Header("Refercnes")]
        [SerializeField] private Line linePrefab;
        [SerializeField] private Transform lineRoot;
        [SerializeField] private List<Line> lines;



        private void Awake()
        {
            Instance = this;
        }

        public Line CreateLineObject()
        {
            Line line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineRoot);
            lines.Add(line);
            return line;
        }

        public void ClearAllLines()
        {
            foreach(Line line in lines)
            {
                line.Clear();
            }
        }
    }
}



