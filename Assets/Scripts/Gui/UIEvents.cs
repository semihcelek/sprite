using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
         Debug.Log("button is pressed");
        //SceneManager.LoadScene("Level");
        GameManager.game = GameManager.GameState.Level;
    }

    public void ReturnMainMenu()
    {
        GameManager.game = GameManager.GameState.MainMenu;
    }

}
