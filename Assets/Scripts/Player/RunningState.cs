using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class RunningState : CharacterState
    {


        private float _playerSpeed = 5f;

        public RunningState(PlayerMovementController playerMovementController) : base(playerMovementController)
        {
        }
        public override void HandleInput(CharacterController playerController, IInputController inputController)
        {
            var move = new Vector3(inputController.HorizontalInput, 0, _playerSpeed);

            playerController.Move(move * Time.deltaTime);

            if (Jump(inputController))
            {
                PlayerMovementController.SetState(new JumpState(PlayerMovementController));
            }
        }

        private bool Jump(IInputController inputController)
        {
            return inputController.VerticalInput == 1f;
        }
    }
}