using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenNotVisible : MonoBehaviour
{
    private Transform playerPosition;
    [SerializeField] float destoryDistance=60;
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(playerPosition.position.z>gameObject.transform.position.z+destoryDistance)
        {
            Destroy(gameObject);
            //Debug.Log("Object is destroyed");
        }
    }


    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);


    //}
}