using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] playermovement movement;
    [SerializeField] Transform playerTransform;
    [SerializeField] topDownJump jumpControl;
    [SerializeField] string helmetSwitchKey;
    AnimatorStateInfo stateInfo;
    float speed;
    Vector3 originalScale, flippedScale;
    void Start()
    {
        speed = movement.moveSpeed;
        originalScale = new Vector3();
        originalScale = playerTransform.localScale;
        flippedScale  = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
    }
    void Move()
    {
        if (playerTransform.GetComponent<topDownJump>().isJumping)
        {

            animator.SetBool("isJumping", true);
            return;
        }
        animator.SetBool("isJumping", false);
        animator.SetBool("isMoving", true);
    }
    void Stop()
    {
        animator.SetBool("isMoving", false);
    }
    void SwitchHelmet()
    {
        animator.SetBool("Helmet", !animator.GetBool("Helmet"));
        movement.moveSpeed = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(helmetSwitchKey) && movement.moveDirection.magnitude==0)   SwitchHelmet();
        if (movement.moveDirection.magnitude == 0)
        {
            Stop();
            if(!playerTransform.GetComponent<topDownJump>().isJumping) animator.SetBool("isJumping", false);
        }
        else if (movement.moveDirection.magnitude != 0)
        {
            Move();
            animator.SetFloat("X", movement.moveDirection.x);
            animator.SetFloat("Y", movement.moveDirection.y);
        }
        if(movement.moveDirection.x > 0)
        {
            playerTransform.localScale = originalScale;
        }
        else if (movement.moveDirection.x < 0)
        {
            playerTransform.localScale = flippedScale;
        }

        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (!stateInfo.IsTag("DontMove"))
        {
            movement.moveSpeed = speed;
        }
        else
        {
            movement.moveSpeed = 0;
        }
    }
}
