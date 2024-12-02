using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class topDownJump : MonoBehaviour
{
    public bool isJumping;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    List<TilemapCollider2D> canJumpAcross;
    [SerializeField] Transform shadow , player;
    Vector3 offset; float velocity, minHeight;

    [SerializeField] float dragCoeff;
    void Start()
    {
        canJumpAcross = new List<TilemapCollider2D>();
        velocity = 0;
        offset = new Vector3();
        offset = player.position - shadow.position;
        minHeight = offset.y;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("CanJumpAcross"))
        {
            canJumpAcross.Add(obj.GetComponent<TilemapCollider2D>());
        }
    }
    void Jump()
    {
        if(!isJumping)
        {
            isJumping = true;
            velocity = jumpSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("DestructingTile"))
        {
            Debug.Log("Stepped on DestructingTile");// for traps etc
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
            foreach(TilemapCollider2D collider in canJumpAcross)
                collider.enabled = false;
            offset += new Vector3(0,velocity*Time.deltaTime,0);
            velocity -= gravity * Time.deltaTime + dragCoeff * velocity;
            if(offset.y <= minHeight)
            {
                isJumping=false;
            foreach(TilemapCollider2D collider in canJumpAcross)
                collider.enabled = true;
                velocity=0;
            }
        }
        player.position = shadow.position + offset;
    }
}
