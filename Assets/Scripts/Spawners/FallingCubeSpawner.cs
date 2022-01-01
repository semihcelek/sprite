using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SemihCelek.Sprinter.Spawners
{
    public class FallingCubeSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject _objectPrefab;
        [SerializeField]
        private float _minWait;
        [SerializeField]
        private float _maxWait;
        [SerializeField]
        private int _maxNumberOfCubeToSpawn;

        private int _numberOfObjectSpawned;

        private Vector3 _spawnArea;

        private void Awake()
        {
            _numberOfObjectSpawned = 0;
            _spawnArea = new Vector3(2.5f, 0, 15);
        }


        public IEnumerator SpawnCoroutine()
        {
            return Spawn();
        }

        private IEnumerator Spawn()
        {
            while (_numberOfObjectSpawned < _maxNumberOfCubeToSpawn)
            {
                yield return new WaitForSeconds(Random.Range(_minWait, _maxWait));
                GameObject spawned = Instantiate(_objectPrefab, RandomPosition(), transform.rotation);

                _numberOfObjectSpawned++;
            }
        }

        private Vector3 RandomPosition()
        {
            return new Vector3(Random.Range(-_spawnArea.x, _spawnArea.x), Random.Range(-_spawnArea.y, _spawnArea.y),
                Random.Range(-_spawnArea.z, _spawnArea.z)) + transform.position;
        }
    }
}