using Sprinter.Game;
using UnityEngine;

namespace Sprinter.Utils
{
    public class FinishLevel : MonoBehaviour
    {
        // private void OnCollisionEnter(Collision collision)
        // {
        //     if (collision.gameObject.CompareTag("Player"))
        //     {
        //         //finish game
        //
        //     }
        // }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.game = GameManager.GameState.IsFinish;
                Debug.Log("Game is finished");
            }
        }
    }
}