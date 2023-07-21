using UnityEngine;
using System.Collections.Generic;

namespace DottedFill
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public List<LevelData> levelData;
        [HideInInspector] public int currentLevel = 1;
        [Space(5)]
        public LevelData playingLevelData;


        #region Properties
        public int TotalGameLevel { get { return levelData.Count; } }
        #endregion




        private void Awake()
        {
            // Check if an instance already exists, and destroy the duplicate
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            // FPS
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            // Make the GameObject persist across scenes
            DontDestroyOnLoad(this.gameObject);         
        }

        public void NextLevel()
        {
            currentLevel++;
            if (currentLevel > levelData.Count)
                currentLevel = levelData.Count;

            Unlock(currentLevel);
            playingLevelData = levelData[currentLevel-1];
        }

  

        private void Unlock(int level)
        {
            if(level > 1 && level <= levelData.Count)
            {
                levelData[level-1].isLocking = false;
            }
        }
    }
}



