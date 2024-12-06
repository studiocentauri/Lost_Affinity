
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    public GameObject laserObject;
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
    int state;
    Vector3 endpoiiinnttt;
    public GameObject playerObject; /// The player object
    private Vector3 lastNonZeroVelocity;

    public Transform[] startPositions;
    void Start()
    {
        laserRenderer = laserObject.GetComponent<LineRenderer>();
        laserRenderer.enabled = false;  // Initially hidden
        laserStartPosition = transform.position;  // The position of the laser emitter
    }

    void Update()
    {
        lastNonZeroVelocity = new Vector2(playerObject.GetComponentInChildren<Animator>().GetFloat("X"), playerObject.GetComponentInChildren<Animator>().GetFloat("Y"));
        //Debug.Log(lastNonZeroVelocity);
        laserStartPosition = transform.position;
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
        laserRenderer.enabled = true;
        
        Vector3 LaserDirection = lastNonZeroVelocity;
        Debug.Log(LaserDirection);
        if(LaserDirection == Vector3.right)
        {
            laserStartPosition = startPositions[0].position;
            state = 0;
        }
        else if(LaserDirection == Vector3.left)
        {
            laserStartPosition = startPositions[1].position;
            state = 1;
        }
        else if( LaserDirection == Vector3.up)
        {
            laserStartPosition = startPositions[2].position;
            state = 2;
        }
        else if(LaserDirection == Vector3.down)
        {
            laserStartPosition = startPositions[3].position;
            state = 3;
        }
        Timelaser += Time.deltaTime;
        
        RaycastHit2D hit = Physics2D.Raycast(laserStartPosition, LaserDirection, maxLaserDistance, collisionLayer);
        float EndPoint;
        if (hit.collider != null)
        {
            
            laserRenderer.positionCount = 2;
            float l = Vector3.Distance(laserStartPosition, hit.point);
            EndPoint = Mathf.Lerp(0, l, Timelaser * laserSpeed);
           
            laserRenderer.SetPosition(0, laserStartPosition);  
            laserRenderer.SetPosition(1, laserStartPosition + LaserDirection * EndPoint);
            
            targetLaserDistance = LaserDirection.magnitude;
            endpoiiinnttt=hit.point;
            Vector3 tri=new Vector3(hit.point.x,hit.point.y,laserRenderer.GetPosition(1).z);
            if(tri==laserRenderer.GetPosition(1))
            {
                hashit=true;
                a=false;
                if (hit.collider.CompareTag("Gates"))
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("GateOpen", true);
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("GateClose", false);
                }
            }
        }
        else
        {

            
            laserRenderer.positionCount = 2;  
            EndPoint = Mathf.Lerp(0, maxLaserDistance, Timelaser * laserSpeed);
            laserRenderer.SetPosition(0, laserStartPosition);
            laserRenderer.SetPosition(1, laserStartPosition + LaserDirection * EndPoint);
            
            targetLaserDistance = maxLaserDistance;
        }
        // Reset current laser distance for smooth animation
      isLaserActive = true;  // Start the laser scaling
    }
    void StartLaserRetraction()
    {
        // Timelaser = 0;
        Vector3 LaserDirection = lastNonZeroVelocity;
        Debug.Log(LaserDirection);
        if (LaserDirection == Vector3.right)
        {
            laserStartPosition = startPositions[0].position;
            state = 0;
        }
        else if (LaserDirection == Vector3.left)
        {
            laserStartPosition = startPositions[1].position;
            state = 1;
        }
        else if (LaserDirection == Vector3.up)
        {
            laserStartPosition = startPositions[2].position;
            state = 2;
        }
        else if (LaserDirection == Vector3.down)
        {
            laserStartPosition = startPositions[3].position;
            state = 3;
        }
        if (hashit)
        {
            t+=Time.deltaTime;
            float yoyo = Mathf.Lerp(0,maxLaserDistance,t*laserSpeed);
            laserRenderer.SetPosition(0, laserStartPosition + LaserDirection*yoyo*iter);

        }
        switch(state)
        {
            case 0:
                if (endpoiiinnttt.x < laserRenderer.GetPosition(0).x)
                {
                    isLaserActive = false;
                    laserRenderer.positionCount = 0;
                    laserRenderer.enabled = false;
                    laserStartPosition = transform.position;
                    hashit = false;
                    Timelaser = 0f;
                    t = 0f;
                    cooled = true;
                    if (usedonce == false) usedonce = true;
                } break;
                case 1:
                if(endpoiiinnttt.x > laserRenderer.GetPosition(0).x)
                {
                    isLaserActive = false;
                    laserRenderer.positionCount = 0;
                    laserRenderer.enabled = false;
                    laserStartPosition = transform.position;
                    hashit = false;
                    Timelaser = 0f;
                    t = 0f;
                    cooled = true;
                    if (usedonce == false) usedonce = true;
                }
                break;
                case 2:
                if(endpoiiinnttt.y < laserRenderer.GetPosition(0).y)
                {
                    isLaserActive = false;
                    laserRenderer.positionCount = 0;
                    laserRenderer.enabled = false;
                    laserStartPosition = transform.position;
                    hashit = false;
                    Timelaser = 0f;
                    t = 0f;
                    cooled = true;
                    if (usedonce == false) usedonce = true;
                }
                break;
                case 3:
                if(endpoiiinnttt.y > laserRenderer.GetPosition(0).y)
                {
                    isLaserActive = false;
                    laserRenderer.positionCount = 0;
                    laserRenderer.enabled = false;
                    laserStartPosition = transform.position;
                    hashit = false;
                    Timelaser = 0f;
                    t = 0f;
                    cooled = true;
                    if (usedonce == false) usedonce = true;
                }
                break;
        }
        
    }
    
}