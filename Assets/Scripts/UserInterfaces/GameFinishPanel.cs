using System;
using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class GameFinishPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameFinishedPanel;

        private void Awake()
        {
            GameStateManager.OnDisplayGameIsFinishedUi += ActivateGameFinishPanel;
        }

        private void OnDestroy()
        {
            GameStateManager.OnDisplayGameIsFinishedUi -= ActivateGameFinishPanel;
        }

        private void ActivateGameFinishPanel()
        {
            gameFinishedPanel.SetActive(true);
        }
    }
}