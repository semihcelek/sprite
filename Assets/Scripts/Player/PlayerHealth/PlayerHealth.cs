using System.Collections;
using SemihCelek.Sprinter.Game;
using UnityEngine;

namespace SemihCelek.Sprinter.Player.PlayerHealth
{
    public class PlayerHealth : MonoBehaviour
    {

        private readonly int _maxHealth = 100;
        private int _health;
        private IDamagable _damagable;

        public delegate void PlayerAction();
        public static event PlayerAction OnDie;
        public static event PlayerAction OnStopMovement;

        public delegate void PlayerGuiAction(int health);
        public static event PlayerGuiAction OnUpdateHealthGui;


        private void Awake()
        {
            _health = _maxHealth;
            OnUpdateHealthGui(_health);
            _damagable = GetComponent<IDamagable>();
        }
        
        private void TakeDamage(int damage)
        {
            _health -= damage;
            OnUpdateHealthGui(_health);
            if (_health <= 0)
            {
                Die();
            }
        }
    
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            TakeDamage(_damagable.HandleHit(hit));
        }
        private void Die()
        {
            if (OnDie != null)
            {
                OnDie();
            }

            if (OnStopMovement != null)
            {
                OnStopMovement();
            }
            StartCoroutine(waitForDeadAnim());
        }



        private IEnumerator waitForDeadAnim()
        {
            yield return new WaitForSeconds(3);

            //playerAnimator.SetBool(isDeadHash, false);
            GameManager.Game = GameManager.GameState.GameOver;
        }
    }
}
