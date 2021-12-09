using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public float minWait = 0.5f;
    public float maxWait = 4f;
    private Vector3 dimentionsOfSpawnerArea;

    //private MeshRenderer renderer; //in order to get the size of the size of mesh

    // Start is called before the first frame update
    void Start()
    {
        dimentionsOfSpawnerArea = new Vector3(3, 0, 30); //size of the tile on renderer.
        StartCoroutine(SpawnCubes());
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            GameObject cube = Instantiate(cubeToSpawn, RandomizeSpawnPositionInMesh(), transform.rotation);
            //Debug.Log("spawning");
        }
    }

    private Vector3 RandomizeSpawnPositionInMesh()
    {
        
        return new Vector3(transform.position.x+Random.Range(-3, dimentionsOfSpawnerArea.x), transform.position.y, transform.position.z+ Random.Range(-30, dimentionsOfSpawnerArea.z));

    }

}
