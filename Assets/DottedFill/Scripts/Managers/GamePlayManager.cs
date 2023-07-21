using UnityEngine;

namespace DottedFill
{
    public class GamePlayManager : MonoBehaviour
    {
        public static GamePlayManager Instance { get; private set; }
        public static event System.Action OnStateChanged;

        public enum GameState
        {
            WAITING,
            PLAYING,
            WIN,
            GAMEOVER,
            PAUSE,
        }


        [Header("Properties")]
        public GameState currentState;
        [SerializeField] private float waitTimeBeforePlaying = 0.5f;



        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            OnStateChanged += OnSwitchState;
        }

        private void OnDisable()
        {
            OnStateChanged -= OnSwitchState;
        }

        private void Start()
        {
            currentState = GameState.PLAYING;
        }



        public void ChangeGameState(GameState state)
        {
            currentState = state;
            OnStateChanged?.Invoke();
        }

        private void OnSwitchState()
        {
            switch (currentState)
            {
                default: break;
                case GameState.WAITING:
          ;
                    break;
                case GameState.PLAYING:
                    break;

                case GameState.WIN:
                    GameManager.Instance.NextLevel();
                    UIGameplayManager.Instance.DisplayWinningMenu(true);

                    // Sound
                    SoundManager.Instance.PlaySound(SoundType.Win, false);
                    break;
                case GameState.GAMEOVER:
     
                    break;
                case GameState.PAUSE:
                    break;
            }
        }
    }
}



