using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game{
    public class GameManager : Singleton<GameManager>
    {
        public static UnityAction OnGameLose, OnGameWin;

        [HideInInspector] public PlayerController Player;

        #region GM State Machine
        public StateMachine<GameManager> GameManagerMachine;
        public InLoadingState LoadingState = new InLoadingState();
        public InGameState InGameState = new InGameState();
        public InPauseState InPauseState = new InPauseState();
        public InMenuState InMenuState = new InMenuState();
        public InWingameState InWingameState = new InWingameState();
        #endregion

        [SerializeField] private Animator FadeAnimator;
        public Animator WinCanvasAnimator;
        public GameObject PausePanel;

        public bool CanPause = true;

        public bool IsLoading
        {
            get => GameManagerMachine.CurrentState == LoadingState;
        }

        public float InitialTimeScale
        {
            get;
            set;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                
                //Initializing Game Manager State Machine.
                GameManagerMachine = new StateMachine<GameManager>(this);

                GameManagerMachine.SetState(InMenuState);

                InitialTimeScale = .4f;
            }
        }

        /// <summary>
        /// Loose the game.
        /// </summary>
        public void LoseGame()
        {
            Player.gameObject.SetActive(false);

            StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().name));
        }

        private void Update()
        {
            GameManagerMachine.CurrentState.TickState(this);
        }

        public void LoadScene(string sceneName) => StartCoroutine(LoadLevelAsync(sceneName));

        /// <summary>
        /// Loads the given scene asynchronous.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        private IEnumerator LoadLevelAsync(string sceneName)
        {
            GameManagerMachine.SetState(LoadingState);

            yield return new WaitForSecondsRealtime(1f);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            GameManagerMachine.SetState(InGameState);
        }

        /// <summary>
        /// Shows/hide the fade.
        /// </summary>
        /// <param name="state"></param>
        public void ShowFade(bool state)
        {
            FadeAnimator.SetBool("ShowFade", state);
        }

        /// <summary>
        /// Set the game to win state.
        /// </summary>
        public void WinGame()
        {
            Player.gameObject.SetActive(false);

            OnGameWin?.Invoke();

            GameManagerMachine.SetState(InWingameState);
        }
    }
}