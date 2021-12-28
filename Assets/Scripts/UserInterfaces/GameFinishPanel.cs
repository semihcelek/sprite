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
            GameStateManager.OnDisplayGameIsFinishedUi += ActivatGameFinishPanel;
        }

        private void OnDestroy()
        {
            GameStateManager.OnDisplayGameIsFinishedUi -= ActivatGameFinishPanel;
        }

        private void ActivatGameFinishPanel()
        {
            gameFinishedPanel.SetActive(true);
        }
    }
}