using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmet_sound : MonoBehaviour
{
public AudioSource helmetsound;

void Update()
{
    if (Input.GetKey(KeyCode.Q))
    {
        helmetsound.Play();
    }
   /* else{
        helmetsound.enabled = false;
    }*/
}
}