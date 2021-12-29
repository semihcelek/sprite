using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SemihCelek.Sprinter.Spawners
{
    public class FallingCubeSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject objectPrefab;
        [SerializeField]
        private float minWait;
        [SerializeField]
        private float maxWait;
        [SerializeField]
        
        private int maxNumberOfCubeToSpwan;
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
            while (_numberOfObjectSpawned < maxNumberOfCubeToSpwan)
            {
                yield return new WaitForSeconds(Random.Range(minWait, maxWait));
                GameObject spawned = Instantiate(objectPrefab, RandomPosition(), transform.rotation);

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