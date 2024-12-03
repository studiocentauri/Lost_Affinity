using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapArea : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!other.gameObject.GetComponent<playermovement>().isAttachedToPlatform && !other.gameObject.GetComponent<topDownJump>().isJumping)
            {
                Debug.Log("Drowned");
            }
        }
    }
}
