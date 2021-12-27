using System.Collections;
using UnityEngine;

namespace SemihCelek.Sprinter.Spawners
{
    public class DropDownSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject dropDownSpawnerPrefab;

        private Vector3 ReturnPositionInMesh()
        {
            return new Vector3(transform.position.x, transform.position.y + 8, transform.position.z);
        }

        public IEnumerator SpawnCoroutine()
        {
            GameObject dropDownSpawner = Instantiate(dropDownSpawnerPrefab, ReturnPositionInMesh(), transform.rotation);
            yield return null;
        }
    }
}