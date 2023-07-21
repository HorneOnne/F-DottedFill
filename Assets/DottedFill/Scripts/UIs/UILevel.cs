using UnityEngine;
using UnityEngine.UI;

namespace DottedFill
{
    public class UILevel : DottedFillCanvas
    {
        [Header("Prefabs")]
        [SerializeField] private LevelBtn levelBtnPrefab;

        [Header("References")]
        [SerializeField] private Button backBtn;
        [SerializeField] private Transform levelRoot;


        private void Start()
        {
            backBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayMainMenu(true);
            });

            LoadLevelUI();
        }

        private void OnDestroy()
        {
            backBtn.onClick.RemoveAllListeners();
        }

        private void LoadLevelUI()
        {            
            int numOfLevel = GameManager.Instance.TotalGameLevel;
            for(int i = 0; i < numOfLevel; i++)
            {
                LevelBtn levelBtn =  Instantiate(levelBtnPrefab, levelRoot);
                levelBtn.LoadLevel(GameManager.Instance.levelData[i].level);
                if (GameManager.Instance.levelData[i].isLocking)
                {
                    levelBtn.Lock();
                }
            }
        }
    }
}
