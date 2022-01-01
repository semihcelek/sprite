using System.Collections;
using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private float _playerSpeed = 2.5f;
        [SerializeField]
        private float _jumpHeight = 1.2f;
        private const float GravityValue = -9.81f;

        private CharacterController _characterController;
        private IInputController _inputController;

        private Vector3 _characterVelocity;

        private bool _isGrounded;
        private bool _isStopped = false;
        private bool _isPushedBack = false;

        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _inputController = GetComponent<IInputController>();
            _characterController = gameObject.GetComponent<CharacterController>();
            PlayerHealthController.OnStopMovement += StopPlayerMove;
            PlayerHealthController.OnPushPlayerWhenTakesDamage += PushCharacter;

            _waitForSeconds = new WaitForSeconds(1);
        }

        private void OnDestroy()
        {
            PlayerHealthController.OnStopMovement -= StopPlayerMove;
            PlayerHealthController.OnPushPlayerWhenTakesDamage -= PushCharacter;
        }

        private void PushCharacter()
        {
            _isPushedBack = true;
            StartCoroutine(WaitPushCoroutine());
        }

        private IEnumerator WaitPushCoroutine()
        {
            yield return _waitForSeconds;
            _isPushedBack = false;
        }

        void Update()
        {
            var move = HorizontalMovement();

            Jump();

            ApplyMovement(move);
        }

        private void ApplyMovement(Vector3 move)
        {
            if (_isPushedBack)
            {
                _characterController.Move(Vector3.back * Time.deltaTime * _playerSpeed);
                _characterVelocity.y += GravityValue * Time.deltaTime;
                _characterController.Move(_characterVelocity * Time.deltaTime);
            }
            else if (_isStopped)
            {
                _characterController.Move(Vector3.zero);
            }
            else
            {
                _characterController.Move(move * Time.deltaTime * _playerSpeed);
                _characterVelocity.y += GravityValue * Time.deltaTime;
                _characterController.Move(_characterVelocity * Time.deltaTime);
            }
        }

        private void Jump()
        {
            if (_inputController.VerticalInput == 1f && _isGrounded)
            {
                _characterVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * GravityValue);
            }
        }

        private Vector3 HorizontalMovement()
        {
            _isGrounded = _characterController.isGrounded;
            if (_isGrounded && _characterVelocity.y < 0)
            {
                _characterVelocity.y = 0f;
            }

            Vector3 move = new Vector3(_inputController.HorizontalInput, 0, _playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            return move;
        }

        private void StopPlayerMove()
        {
            _isStopped = true;
        }
    }
}