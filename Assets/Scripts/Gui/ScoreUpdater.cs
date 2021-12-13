using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text scoretext;
    // Start is called before the first frame update
    private void Awake()
    {
        
        scoretext.text = "0";
        PlayerScore.onUpdateScore += UpdateScoreGui;
    }

    private void UpdateScoreGui(int score)
    {
        scoretext.text = score.ToString();
    }
}
