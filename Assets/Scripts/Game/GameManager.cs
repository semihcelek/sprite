using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool created = false;
    public enum GameState {Idle, MainMenu, LevelOne,LevelTwo, IsGameOver, IsFinish};
    // Start is called before the first frame update

    public static GameState game;

    private string currentScene;




    //Scene scene = SceneManager.GetActiveScene();

    private void Awake()
    {

        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }


        game = GameState.MainMenu;
        currentScene = "MainMenu";
    }


    // Update is called once per frame
    void Update()
    {
        switch (game)
        {
            case GameState.MainMenu:
                //Debug.Log("main menu");
                if (!currentScene.Equals("MainMenu"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("MainMenu");
                    currentScene = "MainMenu";
                }
                break;

            case GameState.LevelOne:
                //Debug.Log("Level");
                if (!currentScene.Equals("Level"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Level");
                    currentScene = "Level";
                }
                break;
            
            case GameState.LevelTwo:
                //Debug.Log("Level");
                if (!currentScene.Equals("Level2"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Level2");
                    currentScene = "Level2";
                }
                break;

            case GameState.IsGameOver:
                //Debug.Log("Game over");
                Time.timeScale = 0;
                currentScene = "GameOver";
                //StartCoroutine(StopTheGame());
                break;
            case GameState.IsFinish:
                //Debug.Log("Game over");
                Time.timeScale = 0;
                currentScene = "IsFinish";
                //StartCoroutine(StopTheGame());
                break;


            default:
                game = GameState.Idle;
                break;
        }
    }


    
}
