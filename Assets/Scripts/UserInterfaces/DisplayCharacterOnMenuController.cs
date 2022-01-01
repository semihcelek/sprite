using SemihCelek.Sprinter.Player;
using SemihCelek.Sprinter.ScriptableObjects;
using UnityEngine;

namespace SemihCelek.Sprinter.UserInterfaces
{
    public class DisplayCharacterOnMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _playerPrefabs;
        [SerializeField]
        private SelectedPlayer _selectedPlayerIndex;

        private GameObject _selectedCharacter;

        private Vector3 _playerPosition;
        private Quaternion _playerRotation;


        private void Awake()
        {
            _selectedPlayerIndex.SelectedPlayerIndex = 0;
            DisplayCharacter();

            _playerPosition = new Vector3(0, 0, -5.2f);
            _playerRotation = Quaternion.Euler(0, 180, 0);
        }

        private void DisplayCharacter()
        {
            _selectedCharacter = Instantiate(_playerPrefabs[_selectedPlayerIndex.SelectedPlayerIndex], _playerPosition,
                _playerRotation);
        }

        public void DisplayNextCharacter()
        {
            Destroy(_selectedCharacter);
            _selectedPlayerIndex.SelectedPlayerIndex++;
            DisplayCharacter();
        }

        public void DisplayPreviousCharacter()
        {
            Destroy(_selectedCharacter);
            _selectedPlayerIndex.SelectedPlayerIndex--;
            DisplayCharacter();
        }
    }
}