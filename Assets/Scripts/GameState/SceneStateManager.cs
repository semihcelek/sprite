using UnityEngine;
using UnityEngine.SceneManagement;

namespace SemihCelek.Sprinter.GameState
{
    public class SceneStateManager : MonoBehaviour
    {
        private void Awake()
        {
            GameStateManager.OnGetMainMenuScene += HandleOnGetMenuScene;
            GameStateManager.OnGetLevelOneScene += HandleOnGetLevelOneScene;
            GameStateManager.OnGetLevelTwoScene += HandleOnGetLevelTwoScene;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGetMainMenuScene -= HandleOnGetMenuScene;
            GameStateManager.OnGetLevelOneScene -= HandleOnGetLevelOneScene;
            GameStateManager.OnGetLevelTwoScene -= HandleOnGetLevelTwoScene;
        }

        private void HandleOnGetMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        private void HandleOnGetLevelOneScene()
        {
            SceneManager.LoadScene(1);
        }

        private void HandleOnGetLevelTwoScene()
        {
            SceneManager.LoadScene(2);
        }
    }
}