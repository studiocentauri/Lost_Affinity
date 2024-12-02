using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatScript : MonoBehaviour
{
    public Transform enemyposition;
    private Vector3 startpos;
    public float maginture,val;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        startpos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 a= enemyposition.position-transform.position;
        if(magnitude(a) < val)
        {
            respawn();  
        }
        enemyposition.position+=new Vector3(maginture*Mathf.Sin(Time.time)*Time.deltaTime,0.0f,0.0f);
    }
    float magnitude(Vector3 pos)
    {
        return pos.x*pos.x+pos.y*pos.y+pos.z*pos.z;
    }
    void respawn()
    {
        canvas.SetActive(true);
        transform.position=startpos;
    }
}
