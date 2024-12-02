using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject;         // The laser object (the sprite)
    public float maxLaserDistance = 20f;   // Max distance the laser can travel
    public float laserWidth = 0.1f;        // Width of the laser beam (can be adjusted)
    public float laserSpeed = 5f;          // Speed of the laser retraction/extension (higher is faster)
    public LayerMask collisionLayer;       // The layer to detect collisions with

    private LineRenderer laserRenderer;  // Sprite renderer of the laser object
    private Vector3 laserStartPosition;    // Position from where the laser will start
    private float currentLaserDistance;    // Current length of the laser
    private float targetLaserDistance;     // Target length of the laser
    private bool isLaserActive = false;    // Whether the laser is currently being fired
    float Timelaser = 0.0f;

    void Start()
    {
        laserRenderer = laserObject.GetComponent<LineRenderer>();
        laserRenderer.enabled = false;  // Initially hidden
        laserStartPosition = transform.position;  // The position of the laser emitter
    }

    void Update()
    {
        // Listen for key press to start the laser
        if (Input.GetKey(KeyCode.K))
        {
            ShootLaser();  // Start shooting the laser when K is pressed
        }

        // Listen for key release to retract the laser
        if (Input.GetKeyUp(KeyCode.K) && isLaserActive)
        {
            // Start retracting the laser
            StartLaserRetraction();
        }

        // Smoothly scale the laser length over time if it's active (extending or retracting)
        if (isLaserActive)
        {
            currentLaserDistance = Mathf.Lerp(currentLaserDistance, targetLaserDistance, Time.deltaTime * laserSpeed);
            laserObject.transform.localScale = new Vector3(currentLaserDistance, laserWidth, 1);  // Scale the laser
        }
        else if (currentLaserDistance > 0)
        {
            // If the laser is not active (key released), retract the laser smoothly
            currentLaserDistance = Mathf.Lerp(currentLaserDistance, 0, Time.deltaTime * laserSpeed);
            laserObject.transform.localScale = new Vector3(currentLaserDistance, laserWidth, 1);

            // If the laser has completely retracted, hide it
            if (currentLaserDistance <= 0.1f)
            {
                laserRenderer.enabled = false;
            }
        }
    }

    void ShootLaser()
    {
        laserRenderer.enabled = true;  // Show the laser
        Vector3 LaserDirection = transform.right;
        Timelaser += Time.deltaTime;
        // Fire a ray from the player's position (or wherever the laser should start)
        RaycastHit2D hit = Physics2D.Raycast(laserStartPosition, LaserDirection, maxLaserDistance, collisionLayer);
        float EndPoint;
        if (hit.collider != null)
        {
            laserRenderer.positionCount = 2;
            float l = Vector3.Distance(laserStartPosition, hit.point);
            EndPoint = Mathf.Lerp(0, l, Timelaser * laserSpeed);
            // If the laser hits something, set the laser's endpoint to the collision point
            laserRenderer.SetPosition(0, laserStartPosition);  // Rotate the laser in the correct direction
            laserRenderer.SetPosition(1, laserStartPosition + LaserDirection * EndPoint);
            // Set the target laser distance to the distance from the emitter to the hit point
            targetLaserDistance = LaserDirection.magnitude;
            Debug.Log("Laser hit object: " + hit.collider.gameObject.name + " at position: " + hit.point);

        }
        else
        {

            // If the laser doesn't hit anything, extend it to the max distance
            laserRenderer.positionCount = 2;  // Keep laser pointing in the right direction
            EndPoint = Mathf.Lerp(0, maxLaserDistance, Timelaser * laserSpeed);
            laserRenderer.SetPosition(0, laserStartPosition);
            laserRenderer.SetPosition(1, laserStartPosition + LaserDirection * EndPoint);
            // Set the target laser distance to the maximum range
            // targetLaserDistance = maxLaserDistance;
        }

        // Reset current laser distance for smooth animation
        currentLaserDistance = 0;
        isLaserActive = true;  // Start the laser scaling
    }

    void StartLaserRetraction()
    {
        Timelaser = 0;
        isLaserActive = false;  // Set laser to not active, start retracting
        laserRenderer.positionCount = 0;  // Hide the laser
    }
}
