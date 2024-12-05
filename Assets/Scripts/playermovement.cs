using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 7.5f;
    public Vector2 moveDirection;
    private Rigidbody2D rb;

    public bool isAttachedToPlatform;

    /* 
       Handles player input for movement.
    
       This method captures raw input from the horizontal and vertical axes and determines the movement direction based on the input.
       If both horizontal and vertical inputs are detected simultaneously, it prioritises the latest input direction.
       If only one axis input is detected, it sets the movement direction accordingly.
       If no input is detected, it stops the movement.
    */

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 && vertical != 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                moveDirection = new Vector2(0, vertical).normalized; // Prioritise vertical
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                moveDirection = new Vector2(horizontal, 0).normalized; // Prioritise horizontal
            }
        }

        else if (horizontal != 0){
            moveDirection = new Vector2(horizontal, 0).normalized;
        }

        else if (vertical != 0){
            moveDirection = new Vector2(0, vertical).normalized;
        }

        else{
            moveDirection = Vector2.zero; // No input, stop movement
        }

        rb.velocity = moveDirection * moveSpeed;
    }
}
