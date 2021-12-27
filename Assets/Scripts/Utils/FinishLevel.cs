using SemihCelek.Sprinter.Game;
using UnityEngine;

namespace SemihCelek.Sprinter.Utils
{
    public class FinishLevel : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Game = GameManager.GameState.Finish;
                Debug.Log("Game is finished");
            }
        }
    }
}