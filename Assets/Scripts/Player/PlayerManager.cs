using SemihCelek.Sprinter.ScriptableObjects;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _playerPrefabs;

        [SerializeField]
        private SelectedPlayer _selectedPlayer;

        private void Awake()
        {
            {
                var cachedTransform = transform;
                Instantiate(_playerPrefabs[_selectedPlayer.SelectedPlayerIndex], cachedTransform.position, cachedTransform.rotation);
            }
        }
    }
}