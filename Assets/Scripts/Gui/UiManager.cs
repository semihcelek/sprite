using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameFinishedPanel;


    private void Update()
    {
        if(GameManager.game==GameManager.GameState.IsGameOver)
        {
            ActivatGameOverPanel();
        }

        if (GameManager.game == GameManager.GameState.IsFinish)
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
