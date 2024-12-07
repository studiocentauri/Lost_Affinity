using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps_sound : MonoBehaviour
{
public AudioSource footstepsSound;

    void Update()
    {
        if(GetComponentInChildren<Animator>().GetBool("isMoving")){
            if(Input.GetKey(KeyCode.Space))
            {
                footstepsSound.enabled = false;
            }
            else
            {
                footstepsSound.enabled = true;
            }
        }
        else
        {
            footstepsSound.enabled = false;
        }

    }
}
