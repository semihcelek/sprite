using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScore : MonoBehaviour
{
    public int score { get; private set; }

    public delegate void UpdateGui(int score);
    public static event UpdateGui onUpdateScore; 
    private void Awake()
    {
        score = 0;
    }

    private void IncreaseScore(int point)
    {
        //collect coins
        score+=point;
        onUpdateScore(score);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag=="Score")
        {
            Debug.Log("score is collided " + score);


            IncreaseScore(20);
            Destroy(hit.gameObject);

        }
    }
}

