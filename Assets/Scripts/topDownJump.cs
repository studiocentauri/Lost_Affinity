using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topDownJump : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] bool isJumping;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    [SerializeField] Rigidbody2D rb;
    
    void Jump()
    {
        if(isGrounded && !isJumping)
        {
            rb.velocity = rb.velocity + new Vector2(0, jumpSpeed);
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
