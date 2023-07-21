using UnityEngine;
using UnityEngine.UI;

namespace DottedFill
{

    public class UIMainMenu : DottedFillCanvas
    {
        private const string privacyURL = "https://doc-hosting.flycricket.io/tap-turn-privacy-policy/b02a29c9-6e45-4183-8bd9-7a9ab53bee25/privacy";

        [Header("Buttons")]
        [SerializeField] private Button informationBtn;
        [SerializeField] private Button musicBtn;
        [SerializeField] private Button soundFXBtn;
        [SerializeField] private Button playBtn;


        [Header("Sprites")]
        [SerializeField] private Sprite soundFXSprite;
        [SerializeField] private Sprite muteSoundFXSprite;
        [SerializeField] private Sprite musicSprite;
        [SerializeField] private Sprite muteMusicSprite;


        // Cached
        private SoundManager soundManager;


        private void Start()
        {
            soundManager = SoundManager.Instance;
            LoadMusicUI();
            LoadSoundFXSUI();
            informationBtn.onClick.AddListener(() =>
            {
                Application.OpenURL(privacyURL);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            musicBtn.onClick.AddListener(() =>
            {
                soundManager.isMusicActive = !soundManager.isMusicActive;
                LoadMusicUI();
                SoundManager.Instance.MuteBackgroundMusic(!soundManager.isMusicActive);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            soundFXBtn.onClick.AddListener(() =>
            {
                soundManager.isSoundFXActive = !soundManager.isSoundFXActive;
                LoadSoundFXSUI();
                SoundManager.Instance.MuteSoundFX(!soundManager.isSoundFXActive);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            playBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayLevelMenu(true);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void LoadMusicUI()
        {
            if (soundManager.isMusicActive)
                musicBtn.image.sprite = musicSprite;
            else
                musicBtn.image.sprite = muteMusicSprite;
        }

        private void LoadSoundFXSUI()
        {
            if (soundManager.isSoundFXActive)
                soundFXBtn.image.sprite = soundFXSprite;
            else
                soundFXBtn.image.sprite = muteSoundFXSprite;
        }


        private void OnDestroy()
        {
            informationBtn.onClick.RemoveAllListeners();
            musicBtn.onClick.RemoveAllListeners();
            soundFXBtn.onClick.RemoveAllListeners();
            playBtn.onClick.RemoveAllListeners();

        }
    }
}
