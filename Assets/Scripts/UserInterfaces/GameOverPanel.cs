using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOverPanel;
        
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
            _gameOverPanel.SetActive(true);
        }
    }
}