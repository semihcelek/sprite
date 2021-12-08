using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    [SerializeField] private float smoothTime = 0.5f;

    private Vector3 cameraVelocity = Vector3.zero;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(offset.x + target.position.x, offset.y + target.position.y, offset.z+target.position.z);
        //transform.position = Vector3.Lerp(transform.position, newPosition,10*Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref cameraVelocity, smoothTime);
    }
}
