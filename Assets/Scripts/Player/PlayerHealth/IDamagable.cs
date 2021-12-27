using UnityEngine;

namespace SemihCelek.Sprinter.Player.PlayerHealth
{
    public interface IDamagable
    { 
        delegate void PlayerMovement();
        int HandleHit(ControllerColliderHit hit);
    }
}