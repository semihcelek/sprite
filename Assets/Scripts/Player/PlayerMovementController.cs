using System.Collections;
using SemihCelek.Sprinter.Input;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private float playerSpeed = 2.0f;
        [SerializeField]
        private float jumpHeight = 1.0f;
        private const float GravityValue = -9.81f;

        private CharacterController _characterController;
        private IInputController _inputController;

        private Vector3 _characterVelocity;

        private bool _isGrounded;
        private bool _isStopped = false;
        private bool _isPushedBack = false;

        private void Awake()
        {
            _inputController = GetComponent<IInputController>();
            _characterController = gameObject.GetComponent<CharacterController>();
            PlayerHealthController.OnStopMovement += StopPlayerMove;
            PlayerHealthController.OnPushPlayerWhenTakesDamage += PushCharacter;
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
            yield return new WaitForSeconds(1);
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
                _characterController.Move(Vector3.back * Time.deltaTime * playerSpeed);
                _characterVelocity.y += GravityValue * Time.deltaTime;
                _characterController.Move(_characterVelocity * Time.deltaTime);
            }
            else if (_isStopped)
            {
                _characterController.Move(Vector3.zero);
            }
            else
            {
                _characterController.Move(move * Time.deltaTime * playerSpeed);
                _characterVelocity.y += GravityValue * Time.deltaTime;
                _characterController.Move(_characterVelocity * Time.deltaTime);
            }
        }

        private void Jump()
        {
            if (_inputController.VerticalInput == 1 && _isGrounded)
            {
                _characterVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * GravityValue);
            }
        }

        private Vector3 HorizontalMovement()
        {
            _isGrounded = _characterController.isGrounded;
            if (_isGrounded && _characterVelocity.y < 0)
            {
                _characterVelocity.y = 0f;
            }

            Vector3 move = new Vector3(_inputController.HorizontalInput, 0, playerSpeed);

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