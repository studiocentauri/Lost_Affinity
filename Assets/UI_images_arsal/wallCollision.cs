using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wallCollision : MonoBehaviour
{
    public Rigidbody2D spaceship;
    public float rebound=10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == spaceship)
        {
            spaceship.AddForce(Vector2.up * rebound*-1, ForceMode2D.Impulse);
        }
    }
}
