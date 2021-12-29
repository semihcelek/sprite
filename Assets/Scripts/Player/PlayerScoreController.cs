using SemihCelek.Sprinter.ScriptableObjects;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerScoreController : MonoBehaviour
    {
        // private int Score { get; set; }
        [SerializeField]
        private PlayerScoreValue score;

        public delegate void UiUpdater(int score);

        public static event UiUpdater OnUpdateScore;

        private void Awake()
        {
            score.score = 0;
        }

        private void IncreaseScore(int point)
        {
            score.score += point;
            OnUpdateScore(score.score);
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