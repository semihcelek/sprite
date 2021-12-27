using System;
using SemihCelek.Sprinter.Player;
using UnityEngine;

namespace SemihCelek.Sprinter.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] playerPrefabs;
        private GameObject _selectedCharacter;
       
        private int _playerIndex;

        private void Awake()
        {
            _playerIndex = 0;
            PlayerManager.OnPlayerSelect += GetSelectedCharacter;
            DisplayCharacter(_playerIndex);
        }

        private void OnDestroy()
        {
            PlayerManager.OnPlayerSelect -= GetSelectedCharacter;
        }

        private void DisplayCharacter(int nextChar)
        {
            _selectedCharacter = Instantiate(playerPrefabs[nextChar],new Vector3(0,0,-5.2f), Quaternion.Euler(0,180,0));
            _playerIndex = nextChar;
        }

        private int GetSelectedCharacter()
        {
            return _playerIndex;
        }

        public void DisplayNextCharacter()
        {
            _playerIndex = Mathf.Clamp(_playerIndex + 1, 0, playerPrefabs.Length-1);
            _selectedCharacter.SetActive(false);

            DisplayCharacter(_playerIndex);
        }
        public void DisplayPreviousCharacter()
        {
            _playerIndex = Mathf.Clamp(_playerIndex - 1, 0, playerPrefabs.Length);
            _selectedCharacter.SetActive(false);
            
            DisplayCharacter(_playerIndex);
        }

    }
}
