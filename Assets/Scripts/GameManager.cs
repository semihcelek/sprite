using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) 
        {
            Time.timeScale=0;
            gameOverPanel.SetActive(true);
        }
    }
}
