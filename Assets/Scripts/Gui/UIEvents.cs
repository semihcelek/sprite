using Sprinter.Game;
using UnityEngine;

namespace Sprinter.Gui
{
    public class UIEvents : MonoBehaviour
    {
        // Start is called before the first frame update
        public void StartGame()
        {
            //SceneManager.LoadScene("Level");
            GameManager.game = GameManager.GameState.LevelOne;
        }

        public void ReturnMainMenu()
        {
            GameManager.game = GameManager.GameState.MainMenu;
        }

        public void GoLevelTwo()
        {
            GameManager.game = GameManager.GameState.LevelTwo;
        }

    }
}
