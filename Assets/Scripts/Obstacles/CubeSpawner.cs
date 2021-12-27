using System.Collections;
using UnityEngine;

namespace SemihCelek.Sprinter.Obstacles
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject cubeToSpawn;
        [SerializeField]
        private float minWait = 0.5f;
        [SerializeField]
        private float maxWait = 4f;

        private Vector3 _dimensionsOfSpawnerArea;

        void Start()
        {
            _dimensionsOfSpawnerArea = new Vector3(3, 0, 30);
            StartCoroutine(SpawnCubes());
        }

        private IEnumerator SpawnCubes()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minWait, maxWait));

                GameObject cube = Instantiate(cubeToSpawn, RandomizeSpawnPositionInMesh(), transform.rotation);
            }
        }

        private Vector3 RandomizeSpawnPositionInMesh()
        {
            return new Vector3(transform.position.x + Random.Range(-3, _dimensionsOfSpawnerArea.x),
                transform.position.y, transform.position.z + Random.Range(-30, _dimensionsOfSpawnerArea.z));
        }
    }
}