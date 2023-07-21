using UnityEngine;

namespace DottedFill
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private LineRenderer lr;

        public void DrawLine(Vector2 pointA, Vector2 pointB)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, pointA);
            lr.SetPosition(1, pointB);
        }

        public void Clear()
        {
            lr.positionCount = 0;
        }
    }
}



