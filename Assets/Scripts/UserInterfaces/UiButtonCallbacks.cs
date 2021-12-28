using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class UiButtonCallbacks : MonoBehaviour
    {
        public void StartGame()
        {
            GameStateManager.ChangeGameState(GameStateManager.GameState.LevelOne);
        }

        public void ReturnMainMenu()
        {
            GameStateManager.ChangeGameState(GameStateManager.GameState.MainMenu);
        }
        
        public void GoLevelTwo()
        {
            GameStateManager.ChangeGameState(GameStateManager.GameState.LevelTwo);
        }
    }
}