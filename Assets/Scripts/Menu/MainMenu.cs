using Sprinter.Player;
using UnityEngine;

namespace Sprinter.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] playerPrefabs;
        private int playerIndex;

        private void Awake()
        {
            playerIndex = 0;
            PlayerManager.onPlayerSelect += ReturnSelectedCharacter;
            CharacterOnScreen(playerIndex);

        }

        private void CharacterOnScreen(int nextChar)
        {
            GameObject character = Instantiate(playerPrefabs[nextChar],new Vector3(0,0,-5.2f), Quaternion.Euler(0,180,0));
            playerIndex = nextChar;
        }

        public int ReturnSelectedCharacter()
        {
            return playerIndex;
        }

        public void NextChar()
        {
            GameObject currentPlayer = GameObject.FindGameObjectWithTag("MenuChar");
            playerIndex = Mathf.Clamp(playerIndex + 1, 0, playerPrefabs.Length-1);
            Destroy(currentPlayer);

            CharacterOnScreen(playerIndex);
        }
        public void PreviousChar()
        {
            GameObject currentPlayer = GameObject.FindGameObjectWithTag("MenuChar");
            playerIndex = Mathf.Clamp(playerIndex - 1, 0, playerPrefabs.Length);
            Destroy(currentPlayer);

            CharacterOnScreen(playerIndex);
        }

    }
}
