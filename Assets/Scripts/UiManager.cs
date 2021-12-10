using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverPanel;


    private void Update()
    {
        if(GameManager.game==GameManager.GameState.IsGameOver)
        {
            ActivatGameOverPanel();
        }
    }

    public void ActivatGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
