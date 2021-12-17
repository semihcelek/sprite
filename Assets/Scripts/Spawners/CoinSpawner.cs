using System.Collections;
using System.Collections.Generic;
using Spawners;
using UnityEngine;

public class CoinSpawner : MonoBehaviour, ISpawner
{
    // Start is called before the first frame update
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int numberOfObjectToSpawn;
    private Vector3 ReturnARandomPositionInMesh()
    {
        return new Vector3(Random.Range(-transform.localScale.x/2, transform.localScale.x/2)+transform.position.x, Random.Range(-transform.localScale.y/2, transform.localScale.y/2)+transform.position.y,
            transform.position.z+Random.Range(-transform.localScale.z/2, transform.localScale.z/2));
    }
    
    // create a function that returns a distanced position for gameobject to instantiate

    private Vector3 ReturnEvenlyPositionInMesh(int index)
    {
        // Debug.Log("Local Position is "+transform.localPosition);
        // Debug.Log("Local Scale is "+transform.localScale);
        return new Vector3(transform.localScale.x/20 +transform.position.x, transform.localScale.y  +transform.position.y,
            transform.localScale.z / numberOfObjectToSpawn * index + transform.position.z);
    }
    
    public IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfObjectToSpawn; i++)
        {
            GameObject coin = Instantiate(coinPrefab,ReturnEvenlyPositionInMesh(i), Quaternion.Euler(0,0,90));
            // Debug.Log("coins are created at" +coin.transform.position);
            // Debug.Log(transform.localScale);
        }
        yield return null;
    }
}
