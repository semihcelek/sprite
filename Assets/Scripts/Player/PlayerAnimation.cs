using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private CharacterController charController;
    private UserInput userInputs;

    private int isRunningHash;
    private int isDeadHash;
    private int isJumpedHash;

   

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        userInputs = GetComponent<UserInput>();

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

        if (userInputs.Vertical== 1&&!charController.isGrounded)
        {
            playerAnimator.SetBool(isRunningHash, false);
            playerAnimator.SetBool(isJumpedHash, true);
        } else
        {
            playerAnimator.SetBool(isJumpedHash, false);
            playerAnimator.SetBool(isRunningHash, true);
        }

    }

    private void OnDieAnimation()
    {
        playerAnimator.SetBool(isJumpedHash, false);
        playerAnimator.SetBool(isRunningHash, false);
        playerAnimator.SetBool(isDeadHash, true);
    }

}
