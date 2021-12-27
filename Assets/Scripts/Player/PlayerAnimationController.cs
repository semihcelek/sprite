using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _playerAnimator;
        private CharacterController _charController;

        private int _isRunningHash;
        private int _isDeadHash;
        private int _isJumpedHash;
       
        private IInputController _inputController;
        
        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
            _charController = GetComponent<CharacterController>();

            _isRunningHash = Animator.StringToHash("isRunning");
            _isDeadHash = Animator.StringToHash("isDead");
            _isJumpedHash = Animator.StringToHash("isJumped");

            _inputController = GetComponent<IInputController>();
            
            PlayerHealth.PlayerHealth.OnDie += OnDieAnimation;
        }
        private void OnDestroy()
        {
            PlayerHealth.PlayerHealth.OnDie -= OnDieAnimation;
        }

        private void Update()
        {
            if(_inputController.Vertical>= 1f &&!_charController.isGrounded)
            {
                _playerAnimator.SetTrigger(_isJumpedHash);
            } else
            {
                _playerAnimator.SetBool(_isRunningHash, true);
            }
        }
        private void OnDieAnimation()
        {
            _playerAnimator.SetTrigger(_isDeadHash);
        }
    }
}
