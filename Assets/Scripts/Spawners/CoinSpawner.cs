using System.Collections;
using UnityEngine;

namespace SemihCelek.Sprinter.Spawners
{
    public class CoinSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject coinPrefab;
        [SerializeField]
        private int numberOfObjectToSpawn;

        private Vector3 ReturnARandomPositionInMesh()
        {
            return new Vector3(
                Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2) + transform.position.x,
                Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2) + transform.position.y,
                transform.position.z + Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));
        }

        private Vector3 ReturnEvenlyPositionInMesh(int index)
        {
            return new Vector3(transform.localScale.x / 20 + transform.position.x,
                transform.localScale.y + transform.position.y,
                transform.localScale.z / numberOfObjectToSpawn * index + transform.position.z);
        }

        public IEnumerator SpawnCoroutine()
        {
            for (int i = 0; i < numberOfObjectToSpawn; i++)
            {
                GameObject coin = Instantiate(coinPrefab, ReturnEvenlyPositionInMesh(i), Quaternion.Euler(0, 0, 90));
            }

            yield return null;
        }
    }
}