using UnityEngine;
using UnityEngine.UI;

namespace DottedFill
{

    public class UIMainMenu : DottedFillCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button informationBtn;
        [SerializeField] private Button musicBtn;
        [SerializeField] private Button soundFXBtn;
        [SerializeField] private Button playBtn;

        private void Start()
        {
            informationBtn.onClick.AddListener(() =>
            {

            });

            musicBtn.onClick.AddListener(() =>
            {

            });

            soundFXBtn.onClick.AddListener(() =>
            {

            });

            playBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayLevelMenu(true);
            });



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
