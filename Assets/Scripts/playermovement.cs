using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed;
    public bool isAttachedToPlatform;
    float speedX, speedY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        speedX = Input.GetAxisRaw("Horizontal")*movSpeed;
        speedY = Input.GetAxisRaw("Vertical")*movSpeed;
        if(Mathf.Abs(speedX)== Mathf.Abs(speedY))
        {
            speedY=0;
        }
        rb.velocity = new Vector2(speedX,speedY);
    }
}