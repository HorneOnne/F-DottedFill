using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DottedFill
{
    public class UIWinning : DottedFillCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button nextLevelBtn;


        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI completeText;

        private void Start()
        {

            nextLevelBtn.onClick.AddListener(() =>
            {               
                Loader.Load(Loader.Scene.Level);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            nextLevelBtn.onClick.RemoveAllListeners();
        }
    }
}
