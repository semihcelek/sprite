using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float tileLenght=60;
    private List<GameObject> activeTiles = new List<GameObject>();

    private Transform PlayerPosition;
    private float zOffset=0;


    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i=0; i<platformPrefabs.Length; i++)
        {
            SpawnTile(Random.Range(0,platformPrefabs.Length)); 
        }
    }
    private void Update()
    {
        if (PlayerPosition.position.z -120 > zOffset-((platformPrefabs.Length)*tileLenght))
        {
            SpawnTile(Random.Range(0, platformPrefabs.Length));
            //Debug.Log(zOffset);
            DeleteTile();
        }

        
    }


    private void SpawnTile(int tileIndex)
    {
       GameObject tile = Instantiate(platformPrefabs[tileIndex], new Vector3(0,-8, 1 * zOffset) , Quaternion.Euler(-90,90,0));
        zOffset += tileLenght;
        activeTiles.Add(tile);

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


    //void Start()
    //{
    //    for(int i = 0; i < platformPrefabs.Length; i++)
    //    {
    //        Instantiate(platformPrefabs[i], new Vector3(0, -8, i * 15), Quaternion.Euler(0, 90, 0));
    //        zOffset += 15;
    //    }
    //}

    //public void RecyclePlatform(GameObject platform)
    //{
    //    //Destroy(platform);
    //    platform.transform.position = new Vector3(0, 0, zOffset);
    //    zOffset += 15;
    //    Debug.Log(zOffset);
    //}
}
