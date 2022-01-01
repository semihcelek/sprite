using System;
using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class GameFinishPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameFinishedPanel;

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
            _gameFinishedPanel.SetActive(true);
        }
    }
}