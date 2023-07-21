using UnityEngine;

namespace DottedFill
{
    public class LevelBtn : DottedFillButton
    {
        [SerializeField] private Sprite lockSprite;
        [SerializeField] private Sprite unlockSprite;
        public LevelData levelData;

        public void LoadLevel(int level)
        {
            this.levelData = GameManager.Instance.levelData[level-1];
            btnText.text = $"{level}";
        }

        public void Lock()
        {
            button.image.sprite = lockSprite;
            btnText.gameObject.SetActive(false);
        }

        public void UnLock()
        {
            button.image.sprite = unlockSprite;
            btnText.gameObject.SetActive(true);
        }

        public override void OnClick()
        {
            if (levelData.isLocking == false)
            {
                GameManager.Instance.playingLevelData = levelData;
                GameManager.Instance.currentLevel = levelData.level;
                Loader.Load(Loader.Scene.Level);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            }
        }
    }
}
