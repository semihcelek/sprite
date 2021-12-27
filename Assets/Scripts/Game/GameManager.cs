using UnityEngine;
using UnityEngine.SceneManagement;

namespace SemihCelek.Sprinter.Game
{
    public class GameManager : MonoBehaviour
    {
        private static bool _created = false;

        public enum GameState
        {
            Idle,
            MainMenu,
            LevelOne,
            LevelTwo,
            GameOver,
            Finish
        };

        public static GameState Game;

        private string _currentScene;

        private void Awake()
        {
            if (!_created)
            {
                DontDestroyOnLoad(gameObject);
                _created = true;
            }
            else
            {
                Destroy(gameObject);
            }

            Game = GameState.MainMenu;
            _currentScene = "MainMenu";
        }

        void Update()
        {
            switch (Game)
            {
                case GameState.MainMenu:
                    if (!_currentScene.Equals("MainMenu"))
                    {
                        Time.timeScale = 1;
                        SceneManager.LoadScene("MainMenu");
                        _currentScene = "MainMenu";
                    }

                    break;

                case GameState.LevelOne:
                    if (!_currentScene.Equals("Level"))
                    {
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Level");
                        _currentScene = "Level";
                    }

                    break;

                case GameState.LevelTwo:
                    if (!_currentScene.Equals("Level2"))
                    {
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Level2");
                        _currentScene = "Level2";
                    }

                    break;

                case GameState.GameOver:
                    Time.timeScale = 0;
                    _currentScene = "GameOver";
                    break;

                case GameState.Finish:
                    Time.timeScale = 0;
                    _currentScene = "IsFinish";
                    break;

                default:
                    Game = GameState.Idle;
                    break;
            }
        }
    }
}