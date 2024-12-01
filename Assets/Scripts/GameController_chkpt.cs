using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_chkpt : MonoBehaviour
{
    // Tag assigned to the triangle object
    public string obstacle_name = "Triangle";
    Vector2 checkpoint_pos;
    // Start is called before the first frame update
    void Start()
    {
        // Get the starting position of the player object
        checkpoint_pos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object collided with has the specified tag
        if (collision.CompareTag(obstacle_name))
        {
            // Destroy the player object
            Die();
        }
    }
    public void UpdateCheckpoint(Vector2 new_checkpoint)
    {
        checkpoint_pos = new_checkpoint;
    }
    void Die()
    {
        // Set the position of the player object to the starting position
        Respawn();

    }
    void Respawn()
    {
        transform.position = checkpoint_pos;
    }
   
}