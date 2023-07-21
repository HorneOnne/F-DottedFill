using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

namespace DottedFill
{
    [CreateAssetMenu(fileName = "GridData_", menuName = "DottedFill/GridData", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Header("Level")]
        public int level;
        public bool isLocking;

        [Header("Camera zoom")]
        public float orthographicCameraSize = 5;

        /*
         * 0 -> EMPTY
         * 1 -> NORMAL NODE
         * 2 -> TARGET NODE
         */
        [Header("Camera zoom")]
        [Space(20)]
        public Array2DInt arrayInt;
       
    }
}



