using SemihCelek.Sprinter.ScriptableObjects;
using UnityEngine;

namespace SemihCelek.Sprinter.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject[] playerPrefabs;

        [SerializeField]
        private SelectedPlayerIndex selectedPlayer;

        private void Awake()
        {
            {
                var cachedTransform = transform;
                Instantiate(playerPrefabs[selectedPlayer.selectedPlayerIndex], cachedTransform.position, cachedTransform.rotation);
            }
        }
    }
}