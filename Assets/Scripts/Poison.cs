using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    // Start is called before the first frame update
    bool start=false;
    public Animator animator;
    float timer=0f;
    public float timelevel;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        start=(transform.position.y>-7f);
        if(start)
        {
            if(animator.GetBool("Helmet"))
            {
                if(timer < timelevel)
                {
                    timer+=Time.deltaTime;
                }
                else
                {
                    KillByPoison();
                }
            }
            else 
            {
                Kill();
            }
        }
    }
    void KillByPoison()
    {
        //Debug.Log("killed by poison");
        start=false;
    }
    void Kill()
    {
        //Debug.Log("killed at start");
        start=false;
        timer=0f;
    }
}
