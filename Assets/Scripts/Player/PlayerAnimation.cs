using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private CharacterController charController;
    private SwipeControls userInputs;

    private int isRunningHash;
    private int isDeadHash;
    private int isJumpedHash;

   

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        userInputs = GetComponent<SwipeControls>();

        isRunningHash = Animator.StringToHash("isRunning");
        isDeadHash = Animator.StringToHash("isDead");
        isJumpedHash = Animator.StringToHash("isJumped");

        PlayerHealth.onDie += OnDieAnimation;
    }
    private void OnDisable()
    {
        PlayerHealth.onDie -= OnDieAnimation;
    }

    private void Update()
    {

        if(userInputs.Vertical== 1
            &&!charController.isGrounded
            )
        {
            //Debug.Log("jump");
            //playerAnimator.SetBool(isRunningHash, false);
            playerAnimator.SetBool(isJumpedHash, true);
        } else
        {
            //Debug.Log("run");
            playerAnimator.SetBool(isJumpedHash, false);
            //playerAnimator.SetBool(isRunningHash, true);
        }

    }

    private void OnDieAnimation()
    {
        playerAnimator.SetBool(isJumpedHash, false);
        playerAnimator.SetBool(isRunningHash, false);
        playerAnimator.SetBool(isDeadHash, true);
    }

}
