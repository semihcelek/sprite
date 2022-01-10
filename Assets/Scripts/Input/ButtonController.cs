using System.Collections;
using SemihCelek.Sprinter.UserInterfaces;
using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class ButtonController : MonoBehaviour, IInputController
    {
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }

        private WaitForSeconds _waitForReset;

        private void Awake()
        {
            UiCharacterControlButtonCallbacks.OnMoveRightButton += MoveRight;
            UiCharacterControlButtonCallbacks.OnMoveLeftButton += MoveLeft;
            UiCharacterControlButtonCallbacks.OnJumpButton += Jump;

            _waitForReset = new WaitForSeconds(0.2f);
        }

        private void OnDestroy()
        {
            UiCharacterControlButtonCallbacks.OnMoveRightButton -= MoveRight;
            UiCharacterControlButtonCallbacks.OnMoveLeftButton -= MoveLeft;
            UiCharacterControlButtonCallbacks.OnJumpButton -= Jump;
        }

        private void MoveRight()
        {
            HorizontalInput = 1;
            StartCoroutine(ResetCharacterMovementCoroutine());
        }

        private void MoveLeft()
        {
            HorizontalInput = -1;
            StartCoroutine(ResetCharacterMovementCoroutine());
        }

        private void Jump()
        {
            VerticalInput = 1;
            StartCoroutine(ResetCharacterMovementCoroutine());
        }

        private IEnumerator ResetCharacterMovementCoroutine()
        {
            yield return _waitForReset;
            HorizontalInput = 0;
            VerticalInput = 0;
        }
    }
}