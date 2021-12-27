using SemihCelek.Sprinter.Player;
using TMPro;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class DisplayPlayerScoreController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoretext;

        private void Awake()
        {
            scoretext.text = "0";
            PlayerScoreController.OnUpdateScore += UpdateScoreGui;
        }

        private void UpdateScoreGui(int score)
        {
            scoretext.text = score.ToString();
        }
    }
}