using Sprinter.Player;
using TMPro;
using UnityEngine;

namespace Sprinter.Gui
{
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
}
