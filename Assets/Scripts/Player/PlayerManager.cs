using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     GameObject[] playerPrefabs;


    private void Awake()
    {
        Instantiate(playerPrefabs[0], transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public static GameObject GetSelectedCharacter()
    //{
    //    return playerPrefabs[0];
    //}
}
