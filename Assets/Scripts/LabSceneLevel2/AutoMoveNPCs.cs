using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AutoMoveNPCs : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    public float moveSpeed = 5f;
    //[SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.01f;
    private Transform currentWaypoint;
    //private Quaternion rotationGoal;


    public bool dialogueCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dialogueCompleted)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

            }
        }
        
    }

    
}
