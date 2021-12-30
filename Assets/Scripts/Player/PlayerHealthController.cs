using System;
using System.Collections;
using SemihCelek.Sprinter.GameState;
using SemihCelek.Sprinter.Utils;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        private readonly int _maxHealth = 100;
        private int _playerHealth;

        private WaitForSeconds _waitForDeadAnimation;

        public delegate void PlayerAction();

        public static event PlayerAction OnDie;
        public static event PlayerAction OnStopMovement;
        public static event PlayerAction OnPushPlayerWhenTakesDamage;

        public delegate void PlayerGuiAction(int health);

        public static event PlayerGuiAction OnUpdateHealthGui;


        private void Awake()
        {
            _playerHealth = _maxHealth;
            OnUpdateHealthGui?.Invoke(_playerHealth);
            _waitForDeadAnimation = new WaitForSeconds(3);
        }

        private void TakeDamage(int damage)
        {
            _playerHealth -= damage;
            OnUpdateHealthGui?.Invoke(_playerHealth);
            if (_playerHealth <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damage = other.GetComponent<DamageDealer>();

            if (damage == null)
            {
                return;
            }

            TakeDamage(damage.DamageAmount);
            OnPushPlayerWhenTakesDamage?.Invoke();
        }

        private void Die()
        {
            OnDie?.Invoke();
            OnStopMovement?.Invoke();
            StartCoroutine(EndGameCoroutine());
        }

        private IEnumerator EndGameCoroutine()
        {
            yield return _waitForDeadAnimation;

            GameStateManager.ChangeGameState(GameStateManager.GameState.GameOver);
        }
    }
}