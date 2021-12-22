using UnityEngine;

namespace Sprinter.Player
{
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
            score+=point;
            onUpdateScore(score);
        }

        // private void OnControllerColliderHit(ControllerColliderHit hit)
        // {
        //     if(hit.transform.tag=="Score")
        //     {
        //         IncreaseScore(20);
        //         Destroy(hit.gameObject);
        //     }
        // }

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

