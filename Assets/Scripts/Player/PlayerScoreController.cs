using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerScore : MonoBehaviour
    {
        public int Score { get; private set; }

        public delegate void UpdateGui(int score);
        public static event UpdateGui OnUpdateScore; 
        private void Awake()
        {
            Score = 0;
        }

        private void IncreaseScore(int point)
        {
            Score+=point;
            OnUpdateScore(Score);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Score"))
            {
                IncreaseScore(20);
                Destroy(other.gameObject);
            }    
        }
    }
}

