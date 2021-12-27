using System.Collections;
using SemihCelek.Sprinter.Input;
using SemihCelek.Sprinter.Player.PlayerHealth;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private float playerSpeed = 2.0f;
        [SerializeField] 
        private float jumpHeight = 1.0f;
        
        private CharacterController _characterController;
        private IInputController _inputController;
        
        private Vector3 _characterVelocity;
        private const float GravityValue = -9.81f;

        private bool _isGrounded;
        private bool _isStopped = false;
        private bool _isPushed = false;

        private void Awake()
        {
            _inputController = GetComponent<IInputController>();
            _characterController = gameObject.GetComponent<CharacterController>();
            PlayerHealth.PlayerHealth.OnStopMovement += StopPlayerMove;
            WallDamage.OnPushCharacter += PushCharacter;
        }

        private void OnDestroy()
        {
            PlayerHealth.PlayerHealth.OnStopMovement -= StopPlayerMove;
            WallDamage.OnPushCharacter -= PushCharacter;
        }

        private void PushCharacter()
        {
            _isPushed = true;
            StartCoroutine(WaitPushCoroutine());
        }

        private IEnumerator WaitPushCoroutine()
        {
            yield return new WaitForSeconds(1);
            _isPushed = false;
        }
        void Update()
        {
            _isGrounded = _characterController.isGrounded;
            if (_isGrounded && _characterVelocity.y < 0)
            {
                _characterVelocity.y = 0f;
            }

            Vector3 move = new Vector3(_inputController.Horizontal, 0, playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (_inputController.Vertical== 1 && _isGrounded)
            {
                _characterVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * GravityValue);
            }
        
            if (_isPushed)
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
        public void StopPlayerMove()
        {
            _isStopped = true;
        }
    }
}
