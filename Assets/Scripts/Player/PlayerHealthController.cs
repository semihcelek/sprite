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
        private int _health;

        private WaitForSeconds _waitForDeadAnimation;

        public delegate void PlayerAction();

        public static event PlayerAction OnDie;
        public static event PlayerAction OnStopMovement;
        public static event PlayerAction OnPushPlayerWhenTakesDamage;

        public delegate void PlayerGuiAction(int health);

        public static event PlayerGuiAction OnUpdateHealthGui;


        private void Awake()
        {
            _health = _maxHealth;
            OnUpdateHealthGui?.Invoke(_health);
            _waitForDeadAnimation = new WaitForSeconds(3);
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;
            OnUpdateHealthGui?.Invoke(_health);
            if (_health <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damage = other.GetComponent<DamageDealer>();

            if (damage == null) return;

            TakeDamage(damage.DamageAmount);
            OnPushPlayerWhenTakesDamage?.Invoke();
        }

        private void Die()
        {
            OnDie?.Invoke();
            OnStopMovement?.Invoke();
            StartCoroutine(WaitForDeadAnimCoroutine());
        }

        private IEnumerator WaitForDeadAnimCoroutine()
        {
            yield return _waitForDeadAnimation;

            GameStateManager.ChangeGameState(GameStateManager.GameState.GameOver);
        }
    }
}