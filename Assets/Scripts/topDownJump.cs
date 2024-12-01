using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topDownJump : MonoBehaviour
{
    public bool canNotJump;
    public bool isJumping;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;

    [SerializeField] Transform player;
    Vector3 offset; float velocity, minHeight;

    [SerializeField] float dragCoeff;
    void Start()
    {
        velocity = 0;
        offset = new Vector3();
        offset = player.position - transform.position;
        minHeight = offset.y;
    }
    void Jump()
    {
        if(!canNotJump && !isJumping)
        {
            isJumping = true;
            velocity = jumpSpeed;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Jump();
        }
        if(isJumping)
        {
            offset += new Vector3(0,velocity*Time.deltaTime,0);
            velocity -= gravity * Time.deltaTime + dragCoeff * velocity;
            if(offset.y <= minHeight)
            {
                isJumping=false;
                velocity=0;
            }
        }
        player.position = transform.position + offset;
    }
}
