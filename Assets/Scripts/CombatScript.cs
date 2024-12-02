using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Transform enemyposition;
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 a= enemyposition.position-transform.position;
        if(magnitude(a) < 2.5)
        {
            respawn();
            
        }
    }
    float magnitude(Vector3 pos)
    {
        return pos.x*pos.x+pos.y*pos.y+pos.z*pos.z;
    }
    void respawn()
    {
        transform.position=startpos;
    }
}
