using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAutoMoveAnimation : MonoBehaviour
{
    private Animator animator;
    private playermovement mover;
    private float moveSpeedX;
    private float moveSpeedY;

    private Vector2 previousPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponentInChildren<Animator>();
        mover = GetComponent<playermovement>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceMovedX = transform.position.x - previousPosition.x;
        //Debug.Log(distanceMovedX);
        float distanceMovedY = transform.position.y - previousPosition.y;

        moveSpeedX = distanceMovedX / Time.deltaTime;
        moveSpeedX /= mover.moveSpeed;
        moveSpeedY = distanceMovedY / Time.deltaTime;
        moveSpeedY /= mover.moveSpeed;

        if (moveSpeedX != 0 || moveSpeedY != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("X", moveSpeedX);
            animator.SetFloat("Y", moveSpeedY);
            /*Debug.Log(moveSpeedX);
            Debug.Log(moveSpeedY);*/
        }
        
        previousPosition = transform.position;
    }
}
