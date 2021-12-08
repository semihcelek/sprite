using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public float minWait = 0.5f;
    public float maxWait = 4f;
    // Start is called before the first frame update
    void Start()
    {
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

            GameObject cube = Instantiate(cubeToSpawn, transform.position, transform.rotation);
            //Debug.Log("spawning");
        }
    }

}
