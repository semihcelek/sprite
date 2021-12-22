using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Sprinter.Utils
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] platformPrefabs;
        [SerializeField] private float tileLenght=60;
        private List<GameObject> _activeTiles = new List<GameObject>();
    
        private Transform PlayerPosition;
        private float zOffset=0;
        private ObjectPool<GameObject> _pool;


        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(CreateGameObject);
        }

        private GameObject CreateGameObject()
        {
            GameObject tile = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector3(0, -8, 0),
                Quaternion.Euler(0, 90, 0));
            tile.SetActive(false);
            return tile;
        }

        private void Start()
        {
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;

            for(int i=0; i<platformPrefabs.Length; i++)
            {
                SpawnTile(0); 
            }
        }
        private void Update()
        {
            if (PlayerPosition.position.z -60 > zOffset-((platformPrefabs.Length)*tileLenght))
            {
                SpawnTile(Random.Range(0, platformPrefabs.Length));
                //Debug.Log(zOffset);
                DeleteTile();
            }

        
        }


        private void SpawnTile(int tileIndex)
        {
            GameObject tile = Instantiate(platformPrefabs[tileIndex], new Vector3(0,-8, 1 * zOffset) , Quaternion.Euler(0,90,0));
            zOffset += tileLenght;
            _activeTiles.Add(tile);

        }

        private void DeleteTile()
        {
            Destroy(_activeTiles[0]);
            _activeTiles.RemoveAt(0);
        }
    }
}
