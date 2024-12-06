using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform moveToLocn;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!other.gameObject.GetComponent<topDownJump>().isJumping) 
            {
                Debug.Log(other.gameObject.tag);
            
                return;
            }
            other.gameObject.GetComponent<playermovement>().isAttachedToPlatform = true;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, moveToLocn.position.y, other.gameObject.transform.position.z);
        }
    }
}
