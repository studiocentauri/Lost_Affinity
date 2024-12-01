using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpCheck : MonoBehaviour
{    
    topDownJump PlayerJumpControl;
    void Start()
    {
        PlayerJumpControl = GameObject.FindWithTag("Shadow").GetComponent<topDownJump>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shadow") && !PlayerJumpControl.isJumping)
        {
            PlayerJumpControl.canNotJump = true;
        }
    }
}