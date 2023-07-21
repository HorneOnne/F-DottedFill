using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

namespace DottedFill
{
    [CreateAssetMenu(fileName = "GridData_", menuName = "DottedFill/GridData", order = 51)]
    public class LevelData : ScriptableObject
    {
        public float orthographicCameraSize = 5;

        [Space(20)]
        public Array2DInt arrayInt;
       
    }

    public enum NodeState
    {
        EMPTY, 
        NORMAL,
        TARGET
    }
}



