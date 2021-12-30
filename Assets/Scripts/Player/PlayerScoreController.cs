using SemihCelek.Sprinter.Utils;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerScoreController : MonoBehaviour
    {
        private int _playerScore;

        public delegate void UiUpdater(int score);

        public static event UiUpdater OnUpdateScore;

        private void Awake()
        {
            _playerScore = 0;
        }

        private void IncreaseScore(int point)
        {
            _playerScore += point;
            OnUpdateScore?.Invoke(_playerScore);
        }

        private void OnTriggerEnter(Collider other)
        {
            ScoreDealer score = other.GetComponent<ScoreDealer>();

            if (score == null)
            {
                return;
            }

            IncreaseScore(20);
            Destroy(other.gameObject);
        }
    }
}