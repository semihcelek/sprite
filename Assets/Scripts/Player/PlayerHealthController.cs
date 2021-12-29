using System;
using System.Collections;
using SemihCelek.Sprinter.GameState;
using SemihCelek.Sprinter.ScriptableObjects;
using SemihCelek.Sprinter.Utils;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        private readonly int _maxHealth = 100;
        
        [SerializeField]
        private PlayerHealthValue playerHealth;
        

        private WaitForSeconds _waitForDeadAnimation;

        public delegate void PlayerAction();

        public static event PlayerAction OnDie;
        public static event PlayerAction OnStopMovement;
        public static event PlayerAction OnPushPlayerWhenTakesDamage;

        public delegate void PlayerGuiAction(int health);

        public static event PlayerGuiAction OnUpdateHealthGui;


        private void Awake()
        {
            playerHealth.playerHealth = _maxHealth;
            OnUpdateHealthGui?.Invoke(playerHealth.playerHealth);
            _waitForDeadAnimation = new WaitForSeconds(3);
        }

        private void TakeDamage(int damage)
        {
            playerHealth.playerHealth -= damage;
            OnUpdateHealthGui?.Invoke(playerHealth.playerHealth);
            if (playerHealth.playerHealth <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damage = other.GetComponent<DamageDealer>();

            if (damage == null) return;
            
            TakeDamage(damage.damageAmount);
            OnPushPlayerWhenTakesDamage?.Invoke();
        }

        private void Die()
        {
            OnDie?.Invoke();
            OnStopMovement?.Invoke();
            StartCoroutine(WaitForDeathAnimationCoroutine());
        }

        private IEnumerator WaitForDeathAnimationCoroutine()
        {
            yield return _waitForDeadAnimation;

            GameStateManager.ChangeGameState(GameStateManager.GameState.GameOver);
        }
    }
}