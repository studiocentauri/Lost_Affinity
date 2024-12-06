using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMovePlayerOnEnd : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    public float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.01f;
    private Transform currentWaypoint;

    public bool hasAllArtifacts;
    private float moveSpeedX;
    private float moveSpeedY;
    Vector2 previousPosition = new Vector2();
    private playermovement mover;
    private Animator animator;
    void OnEnable   ()
    {
        GetComponent<playermovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponentInChildren<Animator>().SetBool("isMoving", false);
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        currentWaypoint.position = transform.position;
        transform.position = currentWaypoint.position;
        previousPosition = transform.position;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isMoving", false);
    }
    void FixedUpdate()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        }
        
        float distanceMovedX = transform.position.x - previousPosition.x;
        //Debug.Log(distanceMovedX);
        float distanceMovedY = transform.position.y - previousPosition.y;
        moveSpeedX = distanceMovedX / Time.deltaTime;
        moveSpeedX /= 3.0f;
        moveSpeedY = distanceMovedY / Time.deltaTime;
        moveSpeedY /= 3.0f;
        if (moveSpeedX != 0 || moveSpeedY != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("X", moveSpeedX);
            animator.SetFloat("Y", moveSpeedY);
            Debug.Log(moveSpeedX);
            Debug.Log(moveSpeedY);
        }
        previousPosition = transform.position;
        if (waypoints.onLastWaypoint && (moveSpeedX == 0 && moveSpeedY == 0))
        {
            //Debug.Log("last");
            animator.SetBool("isMoving", false);
            Debug.Log(animator.GetBool("isMoving"));
        }
    }
}
