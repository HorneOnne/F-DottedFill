using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DottedFill
{
    public class UIGameplay : DottedFillCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button homeBtn;
       

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI levelText;

        private void Start()
        {
            // load level text
            levelText.text = $"{GameManager.Instance.playingLevelData.level}";

            homeBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MainMenuScene);
            });
        }

        private void OnDestroy()
        {
            homeBtn.onClick.RemoveAllListeners();
        }
    }
}
