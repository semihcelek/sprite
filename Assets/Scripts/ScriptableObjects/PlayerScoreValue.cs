using UnityEngine;

namespace SemihCelek.Sprinter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerScore", menuName = "ScriptableObjects/PlayerScore", order = 1)]
    public class PlayerScoreValue : ScriptableObject
    {
        public int score;
    }
}