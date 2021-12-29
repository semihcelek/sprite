using UnityEngine;

namespace SemihCelek.Sprinter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerHealth", menuName = "ScriptableObjects/PlayerHealth", order = 0)]
    public class PlayerHealthValue : ScriptableObject
    {
        public int playerHealth;
    }
}