using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topDownJump : MonoBehaviour
{
    public bool canNotJump;
    [SerializeField] bool isJumping;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    [SerializeField] Rigidbody rb;
    
    void Jump()
    {
        if(!canNotJump && !isJumping)
        {
            rb.velocity = rb.velocity + new Vector3(0,0, jumpSpeed);
            isJumping = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isJumping = false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Jump();
        }
    }
}
