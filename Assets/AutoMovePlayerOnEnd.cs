using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovePlayerOnEnd : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    public float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.01f;
    private Transform currentWaypoint;

    public bool hasAllArtifacts;
    void OnEnable   ()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        currentWaypoint.position = transform.position;
        transform.position = currentWaypoint.position;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        }
    }
}
