using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject[] playerPrefabs;

        public delegate int PlayerSelectionAction();

        public static event PlayerSelectionAction OnPlayerSelect;

        private void Awake()
        {
            if (OnPlayerSelect != null)
            {
                Instantiate(playerPrefabs[OnPlayerSelect()], transform.position, transform.rotation);
            }
            else
            {
                Instantiate(playerPrefabs[0], transform.position, transform.rotation);
            }
        }
    }
}