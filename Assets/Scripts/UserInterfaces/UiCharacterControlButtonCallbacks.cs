using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class UiCharacterControlButtonCallbacks : MonoBehaviour
    {
        public delegate void UiCharacterActions();

        public static event UiCharacterActions OnMoveLeftButton;
        public static event UiCharacterActions OnMoveRightButton;
        public static event UiCharacterActions OnJumpButton;

        public void GoLeft()
        {
            OnMoveLeftButton?.Invoke();
        }

        public void GoRight()
        {
            OnMoveRightButton?.Invoke();
        }

        public void Jump()
        {
            OnJumpButton?.Invoke();
        }
    }
}