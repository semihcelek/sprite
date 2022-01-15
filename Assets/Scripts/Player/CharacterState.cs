using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public abstract class CharacterState
    {
        protected PlayerMovementController PlayerMovementController;

        protected CharacterState(PlayerMovementController playerMovementController)
        {
            PlayerMovementController = playerMovementController;
        }

        public virtual void Start() {}
        public virtual void HandleInput(CharacterController playerController, IInputController inputController){}
    }
}