using UnityEngine;

namespace SemihCelek.Sprinter.GameState
{
    public class GameStateManager : MonoBehaviour
    {
        public delegate void SceneLoadAction();
        public static event SceneLoadAction OnGetMainMenuScene;
        public static event SceneLoadAction OnGetLevelOneScene;
        public static event SceneLoadAction OnGetLevelTwoScene;

        public delegate void UiActions();
        public static event UiActions OnDisplayGameOverUi;
        public static event UiActions OnDisplayGameIsFinishedUi;
        
        public static void ChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Idle:
                    break;
                
                case GameState.MainMenu:
                    Time.timeScale = 1;
                    OnGetMainMenuScene?.Invoke();
                    break;
                
                case GameState.Finish:
                    Time.timeScale = 0;
                    OnDisplayGameIsFinishedUi?.Invoke();
                    break;
                
                case GameState.LevelOne:
                    Time.timeScale = 1;
                    OnGetLevelOneScene?.Invoke();
                    break;
                
                case GameState.LevelTwo:
                    Time.timeScale = 1;
                    OnGetLevelTwoScene?.Invoke();
                    break;
                
                case GameState.GameOver:
                    Time.timeScale = 0;
                    OnDisplayGameOverUi?.Invoke();
                    break;
            }
        }
        public enum GameState
        {
            Idle,
            MainMenu,
            LevelOne,
            LevelTwo,
            GameOver,
            Finish
        };
    }
}