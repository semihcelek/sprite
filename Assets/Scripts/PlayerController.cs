using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;//0 left, 1 middle, 2 right
    public float laneDistance = 4; // the distance between two lane

    [SerializeField] private float jumpForce;
    [SerializeField] private float Gravity = -10;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z =  forwardSpeed;



        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        //Gather the inputs on which lane we should be;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        //Calculate the next position

        Vector3 targetPosition = transform.position.z *  transform.forward  +  transform.position.y * transform.up;

        if(desiredLane ==0)
        {
            targetPosition += Vector3.left * laneDistance;
        } else if( desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.localPosition, targetPosition, 80 *Time.deltaTime);

    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

}
