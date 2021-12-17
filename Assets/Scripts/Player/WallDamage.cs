using UnityEngine;

namespace Player
{
    public class WallDamage : MonoBehaviour, IDamagable
    {
        [SerializeField] private int damagePoint = 0;
        [SerializeField] private GameObject damagerPrefab;

        public static event IDamagable.PlayerMovement onPushCharacter;

        
        public int HandleHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("Damage"))
            {

                if (onPushCharacter != null)
                    onPushCharacter();
                // Debug.Log("take damage from wall");
                // Destroy(hit.gameObject);
                return damagePoint;
            }
            return 0;
        }
    }
}