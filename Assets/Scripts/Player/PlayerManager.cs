using UnityEngine;

namespace Sprinter.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject[] playerPrefabs;
        public delegate int PlayerSelectionAction();
        public static PlayerSelectionAction onPlayerSelect;

        public enum PlayerNames
        {
            Pearl=0,
            Jasper=1
        };


        private void Awake()
        {
            if (onPlayerSelect != null)
            {
                Instantiate(playerPrefabs[onPlayerSelect()], transform.position, transform.rotation);
            }
            else
            {
                Instantiate(playerPrefabs[0], transform.position, transform.rotation);
            }
        }
    }
}
