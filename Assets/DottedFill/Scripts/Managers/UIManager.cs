using UnityEngine;

namespace DottedFill
{

    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public UIMainMenu uiMainMenu;
        public UILevel uiLevel;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
            DisplayMainMenu(true);
        }

        public void CloseAll()
        {
            DisplayMainMenu(false);
            DisplayLevelMenu(false);
        }

        public void DisplayMainMenu(bool isActive)
        {
            uiMainMenu.DisplayCanvas(isActive);
        }

        public void DisplayLevelMenu(bool isActive)
        {
            uiLevel.DisplayCanvas(isActive);
        }

    }
}
