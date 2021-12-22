using System.Collections;
using Sprinter.Game;
using UnityEngine;

namespace Sprinter.Player.PlayerHealth
{
    public class PlayerHealth : MonoBehaviour
    {

        private int maxHealth = 100;
        private int health;
        private IDamagable _damagable;

        public delegate void PlayerAction();
        public static event PlayerAction onDie;
        public static event PlayerAction onStopMovement;


        public delegate void PlayerGuiAction(int health);
        public static event PlayerGuiAction onUpdateHealthGui;


        private void Awake()
        {
            health = maxHealth;
            onUpdateHealthGui(health);
            _damagable = GetComponent<IDamagable>();
        }


        private void TakeDamage(int damage)
        {
            health -= damage;
            onUpdateHealthGui(health);
            if (health <= 0)
                Die();
        }
    
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            TakeDamage(_damagable.HandleHit(hit));
        }
        private void Die()
        {
            if (onDie!=null)
                onDie();

            if (onStopMovement != null)
                onStopMovement();

            StartCoroutine(waitForDeadAnim());
        }



        private IEnumerator waitForDeadAnim()
        {
            yield return new WaitForSeconds(3);

            //playerAnimator.SetBool(isDeadHash, false);
            GameManager.game = GameManager.GameState.IsGameOver;
        }
    }
}
