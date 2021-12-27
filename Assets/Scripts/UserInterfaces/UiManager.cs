using SemihCelek.Sprinter.Game;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private GameObject gameFinishedPanel;

        private void Update()
        {
            if (GameManager.Game == GameManager.GameState.GameOver)
            {
                ActivatGameOverPanel();
            }

            if (GameManager.Game == GameManager.GameState.Finish)
            {
                ActivatGameFinishPanel();
            }
        }

        public void ActivatGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void ActivatGameFinishPanel()
        {
            gameFinishedPanel.SetActive(true);
        }
    }
}