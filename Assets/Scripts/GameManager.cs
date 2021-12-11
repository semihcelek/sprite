using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool created = false;
    public enum GameState {Idle, MainMenu, Level, IsGameOver};
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
    }

    void Start()
    {
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

            case GameState.Level:
                //Debug.Log("Level");
                if (!currentScene.Equals("Level"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Level");
                    currentScene = "Level";
                }
                break;

            case GameState.IsGameOver:
                //Debug.Log("Game over");
                Time.timeScale = 0;
                currentScene = "gameover";
                //StartCoroutine(StopTheGame());
                break;


            default:
                game = GameState.Idle;
                break;
        }
    }

    //IEnumerator StopTheGame()
    //{
    //    yield return new WaitForSeconds(2);
    //    Debug.Log("Game over");
    //    Time.timeScale = 0;
    //    currentScene = "gameover";
    //}


    //public void ChangeGameState(GameState gs)
    //{
    //    switch (gState)
    //    {
    //        case GameState.MainMenu:
    //           Debug.Log("main menu");
    //            break;

    //        case GameState.Level:
    //            Debug.Log("Level");
    //            break;

    //        case GameState.IsGameOver:
    //            Debug.Log("Game over");
    //            break;


    //        default:
    //            gs = GameState.Idle;
    //            break;
    //    }
    //}
}
