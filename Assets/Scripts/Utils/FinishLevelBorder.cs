using SemihCelek.Sprinter.GameState;
using UnityEngine;

namespace SemihCelek.Sprinter.Utils
{
    public class FinishLevelBorder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            bool isPlayer = other.TryGetComponent(out CharacterController characterController);

            if (isPlayer)
            {
                GameStateManager.ChangeGameState(GameStateManager.GameState.Finish);
            }
        }
    }
}