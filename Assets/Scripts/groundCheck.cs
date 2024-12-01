using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class groundCheck : MonoBehaviour
{    
    topDownJump PlayerJumpControl;
    void Start()
    {
        PlayerJumpControl = GameObject.FindWithTag("Shadow").GetComponent<topDownJump>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            PlayerJumpControl.canNotJump = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            PlayerJumpControl.canNotJump = false;
        }
    }
}