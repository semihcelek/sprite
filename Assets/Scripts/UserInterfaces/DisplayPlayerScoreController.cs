using SemihCelek.Sprinter.Player;
using TMPro;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class DisplayPlayerScoreController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText.text = "0";
            PlayerScoreController.OnUpdateScore += UpdateScoreGui;
        }

        private void UpdateScoreGui(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}