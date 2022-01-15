using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public abstract class CharacterStateMachine : MonoBehaviour
    {
        protected CharacterState State;

        public void SetState(CharacterState state)
        {
            State = state;
            State.Start();
        }
    }
}