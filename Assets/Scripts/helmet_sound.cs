using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmet_sound : MonoBehaviour
{
public AudioSource helmetsound;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Q))
    {
        if(GetComponent<Rigidbody2D>().velocity.magnitude == 0)    helmetsound.Play();
    }
   /* else{
        helmetsound.enabled = false;
    }*/
}
}