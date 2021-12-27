using UnityEngine;

namespace SemihCelek.Sprinter.Spawners
{
    public class Spawner : MonoBehaviour
    {
        private ISpawner _spawner;
        private void Awake()
        {
            _spawner = GetComponent<ISpawner>();
        }
        void Start()
        {
            StartCoroutine(_spawner.SpawnCoroutine());
        }
    }
}
