using System.Collections;
using UnityEngine;

namespace Sprinter.Spawners
{
    public class DropDownSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private GameObject dropDownSpawnerPrefab;
        // Start is called before the first frame update
        private Vector3 ReturnPositionInMesh()
        {
            return new Vector3(transform.position.x,transform.position.y+8,transform.position.z);
        }
        public IEnumerator Spawn()
        {
            GameObject dropDownSpawner = Instantiate(dropDownSpawnerPrefab,ReturnPositionInMesh(), transform.rotation);
            yield return null;
        }
    }
}
