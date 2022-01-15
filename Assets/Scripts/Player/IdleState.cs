using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class IdleState : CharacterState
    {
        public IdleState(PlayerMovementController playerMovementController) : base(playerMovementController)
        {
        }

        public override void Start()
        {
            PlayerMovementController.SetState(new RunningState(PlayerMovementController));
        }

        // public override void HandleInput(CharacterController playerController, IInputController inputController)
        // {
        // }

 
    }
}