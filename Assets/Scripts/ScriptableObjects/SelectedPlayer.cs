using UnityEngine;

namespace SemihCelek.Sprinter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SelectedPlayer", menuName = "ScriptableObjects/SelectedPlayer", order = 0)]
    public class SelectedPlayer : ScriptableObject
    {
        public int SelectedPlayerIndex;
    }
}