using SemihCelek.Sprinter.Game;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class UIEvents : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Game = GameManager.GameState.LevelOne;
        }

        public void ReturnMainMenu()
        {
            GameManager.Game = GameManager.GameState.MainMenu;
        }

        public void GoLevelTwo()
        {
            GameManager.Game = GameManager.GameState.LevelTwo;
        }
    }
}