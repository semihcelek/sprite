using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    //private UserInput userInput;
    // private SwipeControls userInput;
    private bool stopPlayer = false;
    private bool isPlayerPushed = false;
    private IInput _input;



    private void Awake()
    {
        // userInput = GetComponent<SwipeControls>();
        _input = GetComponent<IInput>();
        controller = gameObject.GetComponent<CharacterController>();
        PlayerHealth.onStopMovement += StopPlayerMove;
        WallDamage.onPushCharacter += PushCharacter;
    }

    private void OnDestroy()
    {
        PlayerHealth.onStopMovement -= StopPlayerMove;
        WallDamage.onPushCharacter -= PushCharacter;
    }

    private void PushCharacter()
    {
        isPlayerPushed = true;
        StartCoroutine(WaitPush());
        
    }

    private IEnumerator WaitPush()
    {
        yield return new WaitForSeconds(1);
        isPlayerPushed = false;
    }

    private void Start()
    {

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(_input.Horizontal, 0, playerSpeed);

        if (move != Vector3.zero)
        {
           gameObject.transform.forward = move;
        }

        if (_input.Vertical== 1 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        if (isPlayerPushed)
        {
            controller.Move(Vector3.back * Time.deltaTime * playerSpeed);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        else if (stopPlayer)
        {
            controller.Move(Vector3.zero);
        } 
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        
        // Debug.Log("hori" + _input.Horizontal);
        // Debug.Log( "ver " + _input.Vertical);
    }
    public void StopPlayerMove()
    {
        stopPlayer = true;
    }
    
    

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.transform.tag == "Obstacle")
    //    {
    //        isCollided = true;
    //        playerAnimator.SetBool(isDeadHash, true);
    //        //GameManager.isGameOver = true;
    //        //GameManager.game = GameManager.GameState.IsGameOver;
    //        StartCoroutine(waitForDeadAnim());

    //    }

    //}

    //private IEnumerator  waitForDeadAnim()
    //{
    //    yield return new WaitForSeconds(3);

    //    playerAnimator.SetBool(isDeadHash, false);
    //    GameManager.game = GameManager.GameState.IsGameOver;
    //}







    //    private CharacterController controller;
    //    private Vector3 direction;
    //    public float forwardSpeed;

    //    private int desiredLane = 1;//0 left, 1 middle, 2 right
    //    public float laneDistance = 4; // the distance between two lane

    //    [SerializeField] private float jumpForce;
    //    [SerializeField] private float Gravity = -10;



    //    void Start()
    //    {
    //        controller = GetComponent<CharacterController>();
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        direction.z =  forwardSpeed;



    //        if (controller.isGrounded)
    //        {
    //            direction.y = -1;
    //            if (Input.GetKeyDown(KeyCode.UpArrow))
    //            {
    //                Jump();
    //            }
    //        }
    //        else
    //        {
    //            direction.y += Gravity * Time.deltaTime;
    //        }

    //        //Gather the inputs on which lane we should be;

    //        if(Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            desiredLane++;
    //            if (desiredLane == 3)
    //                desiredLane = 2;
    //        }

    //        if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        {
    //            desiredLane--;
    //            if (desiredLane == -1)
    //                desiredLane = 0;
    //        }
    //        //Calculate the next position

    //        Vector3 targetPosition = transform.position.z *  transform.forward  +  transform.position.y * transform.up;

    //        if(desiredLane ==0)
    //        {
    //            targetPosition += Vector3.left * laneDistance;
    //        } else if( desiredLane == 2)
    //        {
    //            targetPosition += Vector3.right * laneDistance;
    //        }

    //        //transform.position = targetPosition;
    //        transform.position = Vector3.Lerp(transform.localPosition, targetPosition, 80 *Time.deltaTime);

    //    }
    //    private void FixedUpdate()
    //    {
    //        controller.Move(direction * Time.fixedDeltaTime);
    //    }

    //    private void Jump()
    //    {
    //        direction.y = jumpForce;
    //    }

}
