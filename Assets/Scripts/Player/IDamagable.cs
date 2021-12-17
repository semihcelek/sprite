using UnityEngine;

namespace Player
{
    public interface IDamagable
    {
        public delegate void PlayerMovement();
        // public static event PlayerMovement pushCharacter;

        public int HandleHit(ControllerColliderHit hit);
    }
}