using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject;         // The laser object (the sprite)
    public float maxLaserDistance = 20f;   // Max distance the laser can travel
    public float laserWidth = 0.1f;        // Width of the laser beam (can be adjusted)
    public float laserSpeed = 10f;         // Speed of the laser extension (higher is faster)
    public LayerMask collisionLayer;       // The layer to detect collisions with

    private SpriteRenderer laserRenderer;  // Sprite renderer of the laser object
    private Vector3 laserStartPosition;    // Position from where the laser will start
    private float targetLaserDistance;     // Target length of the laser
    private bool isLaserActive = false;    // Whether the laser is currently being fired
    private bool isLaserRetracting = false; // Whether the laser is retracting
    private float currentLaserDistance;    // Current length of the laser

    void Start()
    {
        laserRenderer = laserObject.GetComponent<SpriteRenderer>();
        laserRenderer.enabled = false;  // Initially hidden
        laserStartPosition = transform.position;  // The position of the laser emitter
    }

    void Update()
    {
        // Listen for key press to start the laser
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShootLaser();  // Start shooting the laser when K is pressed
        }
        
        // Listen for key release to start retracting the laser
        if (Input.GetKeyUp(KeyCode.K))
        {
            isLaserRetracting = true;  // Start retracting the laser
        }

        // Smoothly scale the laser length over time if it's active
        if (isLaserActive && !isLaserRetracting)
        {
            currentLaserDistance = Mathf.Lerp(currentLaserDistance, targetLaserDistance, Time.deltaTime * laserSpeed);
            laserObject.transform.localScale = new Vector3(currentLaserDistance, laserWidth, 1);  // Scale the laser
        }

        // Smoothly retract the laser when the key is released
        if (isLaserRetracting)
        {
            currentLaserDistance = Mathf.Lerp(currentLaserDistance, 0, Time.deltaTime * laserSpeed);
            laserObject.transform.localScale = new Vector3(currentLaserDistance, laserWidth, 1);

            // If the laser has completely retracted, hide it
            if (currentLaserDistance <= 0.1f)
            {
                laserRenderer.enabled = false;
                isLaserRetracting = false;  // Stop retracting
                isLaserActive = false;      // Stop the laser
            }
        }
    }

    void ShootLaser()
    {
        laserRenderer.enabled = true;  // Show the laser

        // Fire a ray from the player's position (or wherever the laser should start)
        RaycastHit2D hit = Physics2D.Raycast(laserStartPosition, transform.right, maxLaserDistance, collisionLayer);

        if (hit.collider != null)
        {
            // If the laser hits something, set the laser's endpoint to the collision point
            Vector2 direction = hit.point - (Vector2)laserStartPosition;
            laserObject.transform.position = laserStartPosition;  // Set the laser's position to the emitter
            laserObject.transform.right = direction.normalized;  // Rotate the laser in the correct direction

            // Set the target laser distance to the distance from the emitter to the hit point
            targetLaserDistance = direction.magnitude;
        }
        else
        {
            // If the laser doesn't hit anything, extend it to the max distance
            laserObject.transform.position = laserStartPosition;
            laserObject.transform.right = transform.right;  // Keep laser pointing in the right direction

            // Set the target laser distance to the maximum range
            targetLaserDistance = maxLaserDistance;
        }

        // Reset current laser distance for smooth animation
        currentLaserDistance = 0;
        isLaserActive = true;  // Start the laser scaling
    }
}
