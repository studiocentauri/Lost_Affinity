using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool canLoop;
    public bool onLastWaypoint;
    public bool reverseOrder;
    private int variable = 1;
    private void OnDrawGizmos()
    {
        foreach( Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f);
        }
        Gizmos.color = Color.red;

        for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        if (canLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null) return transform.GetChild(0);

        int currentIndex = currentWaypoint.GetSiblingIndex();
        int nextIndex = currentIndex;

        if (reverseOrder)
        {
            nextIndex += variable;
            if(nextIndex == transform.childCount)
            {
                
                if (canLoop)
                {
                    nextIndex = transform.childCount - 2;
                    variable = -1;
                }
                else
                {
                    nextIndex -= variable;
                }
            }
            if(nextIndex < 0)
            {
                if (canLoop)
                {
                    nextIndex = 0;
                    variable = 1;
                }
                else
                {
                    nextIndex = 0;
                    variable = 0;
                }
            }
        }
        else
        {
            nextIndex += 1;
            if(nextIndex == transform.childCount)
            {
                if (canLoop)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex -= 1;
                }
            }
        }

        Debug.Log(nextIndex);
        return transform.GetChild(nextIndex);   
        
        
    }
}
