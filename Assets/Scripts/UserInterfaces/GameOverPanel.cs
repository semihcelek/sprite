using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;
        
        private void Awake()
        {
            GameStateManager.OnDisplayGameOverUi += ActivateGameOverPanel;
        }

        private void OnDestroy()
        {
            GameStateManager.OnDisplayGameOverUi -= ActivateGameOverPanel;
        }

        private void ActivateGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}