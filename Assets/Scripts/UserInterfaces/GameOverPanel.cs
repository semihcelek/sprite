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
            GameStateManager.OnDisplayGameOverUi += ActivatGameOverPanel;
        }

        private void OnDestroy()
        {
            GameStateManager.OnDisplayGameOverUi -= ActivatGameOverPanel;
        }
    
        public void ActivatGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}