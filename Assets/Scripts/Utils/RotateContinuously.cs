using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    [SerializeField] private float xRotationSpeed=0f;
    [SerializeField] private float yRotationSpeed=0f;
    [SerializeField] private float zRotationSpeed=0f;



    private Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation += Vector3.up * Time.deltaTime * rotationSpeed;
        transform.Rotate(rotation*Time.deltaTime);;
    }
    
}
