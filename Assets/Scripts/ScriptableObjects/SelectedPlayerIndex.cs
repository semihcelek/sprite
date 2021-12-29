using UnityEngine;

namespace SemihCelek.Sprinter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SelectedPlayerIndex", menuName = "ScriptableObjects/SelectedPlayerIndex", order = 0)]
    public class SelectedPlayerIndex : ScriptableObject
    {
        public int selectedPlayerIndex;
    }
}