using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class JumpState : CharacterState
    {
        private float _playerSpeed = 4f;

        private float _jumpHeight = 1.2f;
        private const float GravityValue = -9.81f;
        private CharacterController _characterController;

        public JumpState(PlayerMovementController playerMovementController) : base(playerMovementController)
        {
        }
        public override void Start()
        {
            _characterController = PlayerMovementController.GetComponent<CharacterController>();
        }

        public override void HandleInput(CharacterController playerController, IInputController inputController)
        {
            var jump = Mathf.Sqrt(_jumpHeight * -3.0f * GravityValue);

            var jumpMovement = new Vector3(0, jump, _playerSpeed);

            playerController.Move(jumpMovement * Time.deltaTime);

            playerController.Move(new Vector3(0, -jump, _playerSpeed)* Time.deltaTime);
            
            PlayerMovementController.SetState(new RunningState(PlayerMovementController));
        }
    }
}