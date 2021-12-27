using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerScoreController : MonoBehaviour
    {
        private int Score { get; set; }

        public delegate void UiUpdater(int score);

        public static event UiUpdater OnUpdateScore;

        private void Awake()
        {
            Score = 0;
        }

        private void IncreaseScore(int point)
        {
            Score += point;
            OnUpdateScore(Score);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Score"))
            {
                IncreaseScore(20);
                Destroy(other.gameObject);
            }
        }
    }
}