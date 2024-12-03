using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject;         // The laser object (the sprite)
    public float maxLaserDistance = 20f;   // Max distance the laser can travel
    public float laserWidth = 0.1f;        // Width of the laser beam (can be adjusted)
    public float laserSpeed = 5f;          // Speed of the laser retraction/extension (higher is faster)
    public LayerMask collisionLayer;       // The layer to detect collisions with
    bool a;
    private LineRenderer laserRenderer;  // Sprite renderer of the laser object
    private Vector3 laserStartPosition;    // Position from where the laser will start
    private float currentLaserDistance;    // Current length of the laser
    private float targetLaserDistance;     // Target length of the laser
    private bool isLaserActive = false;    // Whether the laser is currently being fired
    float Timelaser = 0.0f;
    public float iter;
    float t=0f;
    float t2=0f;
    bool hashit=false;
    bool cooled=false;
    bool usedonce=false;
    public float cooldown;
    Vector3 endpoiiinnttt;
    void Start()
    {
        laserRenderer = laserObject.GetComponent<LineRenderer>();
        laserRenderer.enabled = false;  // Initially hidden
        laserStartPosition = transform.position;  // The position of the laser emitter
    }

    void Update()
    {
        // Listen for key press to start the laser
        if (Input.GetKeyDown(KeyCode.K))
        {
            a=true;
        }
        if(a && !cooled)
        {
            ShootLaser();
        }

        // Listen for key release to retract the laser
        if (hashit)
        {
            // Start retracting the laser
            StartLaserRetraction();
        }
        if(cooled)
        {
            
            t2+=Time.deltaTime;
            if(t2<cooldown)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    a=true;
                }
                if(a && !cooled)
                {
                    ShootLaser();
                }

                // Listen for key release to retract the laser
                if (hashit)
                {
                    // Start retracting the laser
                    StartLaserRetraction();
                }
            }
            else
            {
                t2=0f;
                cooled=false;
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
            endpoiiinnttt=hit.point;
            Vector3 tri=new Vector3(hit.point.x,hit.point.y,laserRenderer.GetPosition(1).z);
            if(tri==laserRenderer.GetPosition(1))
            {
                hashit=true;
                a=false;
            }
        }
        else
        {

            // If the laser doesn't hit anything, extend it to the max distance
            laserRenderer.positionCount = 2;  // Keep laser pointing in the right direction
            EndPoint = Mathf.Lerp(0, maxLaserDistance, Timelaser * laserSpeed);
            laserRenderer.SetPosition(0, laserStartPosition);
            laserRenderer.SetPosition(1, laserStartPosition + LaserDirection * EndPoint);
            // Set the target laser distance to the maximum range
            targetLaserDistance = maxLaserDistance;
        }

        // Reset current laser distance for smooth animation
        isLaserActive = true;  // Start the laser scaling
    }

    void StartLaserRetraction()
    {
        // Timelaser = 0;
        if(hashit)
        {
            t+=Time.deltaTime;
            float yoyo = Mathf.Lerp(0,maxLaserDistance,t*laserSpeed);
            laserRenderer.SetPosition(0, laserStartPosition + transform.right*yoyo*iter);

        }
        
        if(endpoiiinnttt.x < laserRenderer.GetPosition(0).x)
        {
            isLaserActive = false;  // Set laser to not active, start retracting
            laserRenderer.positionCount = 0;  // Hide the laser
            laserRenderer.enabled = false;
            laserStartPosition=transform.position;
            hashit=false;
            Timelaser=0f;
            t=0f;
            cooled=true;
            if(usedonce==false)usedonce=true;
        }
        //Debug.Log(laserStartPosition+transform.right*Time.deltaTime*laserSpeed);
    }
}
