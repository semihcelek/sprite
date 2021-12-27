using UnityEngine;

namespace SemihCelek.Sprinter.Player.PlayerHealth
{
    public class WallDamage : MonoBehaviour, IDamagable
    {
        [SerializeField] 
        private int damagePoint = 0;
        [SerializeField] 
        private GameObject damagerPrefab;

        public static event IDamagable.PlayerMovement OnPushCharacter;
        
        public int HandleHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("Damage"))
            {
                if (OnPushCharacter != null)
                {
                    OnPushCharacter();
                }
                return damagePoint;
            }
            return 0;
        }
    }
}