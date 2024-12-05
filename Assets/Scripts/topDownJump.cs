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
    [SerializeField] List<Collider2D> canJumpAcross;
    
    [SerializeField] Transform shadow , player;
    Vector3 offset; float velocity, minHeight;
    float ground;
    [SerializeField] float dragCoeff;
    void Start()
    {
        velocity = 0;
        offset = new Vector3();
        offset = player.position - shadow.position;
        ground = offset.y;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("CanJumpAcross"))
        {
            canJumpAcross.Add(obj.GetComponent<Collider2D>());
        }
//        canJumpAcross.Add(GameObject.FindGameObjectWithTag("BlueItem").GetComponent<EdgeCollider2D>());
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
            foreach(Collider2D collider in canJumpAcross)
                if(collider!=null) collider.enabled = false;
            offset += new Vector3(0,velocity*Time.deltaTime,0);
            velocity -= gravity * Time.deltaTime + dragCoeff * velocity;
            if(offset.y <= ground)
            {
                isJumping=false;
            foreach(Collider2D collider in canJumpAcross)
                if(collider!=null) collider.enabled = true;
                velocity=0;
            }
        }
        else
        {
            offset = new Vector3(0, ground, 0);
        }
        player.position = shadow.position + offset;
        //Debug.Log(offset);
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log(other.gameObject.name);
    //    if (other.gameObject.CompareTag("Player") && isJumping)
    //    {
    //        isJumping = false;
    //        Debug.Log("detected player");
    //    }
    //}
}
