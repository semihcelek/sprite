using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _playerAnimator;
        private CharacterController _characterController;

        private int _isRunningHash;
        private int _isDeadHash;
        private int _isJumpedHash;

        private IInputController _inputController;

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();

            _isRunningHash = Animator.StringToHash("isRunning");
            _isDeadHash = Animator.StringToHash("isDead");
            _isJumpedHash = Animator.StringToHash("isJumped");

            _inputController = GetComponent<IInputController>();

            PlayerHealthController.OnDie += OnDieAnimation;
        }

        private void OnDestroy()
        {
            PlayerHealthController.OnDie -= OnDieAnimation;
        }

        private void Update()
        {
            if (_inputController.VerticalInput >= 1f && !_characterController.isGrounded)
            {
                _playerAnimator.SetTrigger(_isJumpedHash);
            }
            else
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