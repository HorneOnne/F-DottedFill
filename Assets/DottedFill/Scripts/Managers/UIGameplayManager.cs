using UnityEngine;

namespace DottedFill
{
    public class UIGameplayManager : MonoBehaviour
    {
        public static UIGameplayManager Instance { get; private set; }

        public UIGameplay uiGameplay;
        public UIWinning uiWinning;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
        }

        public void CloseAll()
        {
            DisplayWinningMenu(false);
        }

        public void DisplayWinningMenu(bool isActive)
        {
            uiWinning.DisplayCanvas(isActive);
        }


    }
}
