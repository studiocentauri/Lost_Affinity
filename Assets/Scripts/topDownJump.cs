using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topDownJump : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    [SerializeField] Rigidbody2D rb;
    
    void Jump()
    {
        if(isGrounded && !isJumping)
        {
            rb.velocity = rb.velocity + new Vector2(0, jumpSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
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
