using UnityEngine;

public class PlatformOscillation : MonoBehaviour
{
    private Vector3 startPoint; 
    private Vector3 endPoint; 
    public float speed = 2f;
    public Vector3 endPointCoords;
    private Vector3 targetPosition;
    public bool movementIsTriggered;
    public Vector3 direction;
    void Start()
    {
        startPoint = transform.position;
        endPoint = transform.position;
        SetStartPoint();
        SetEndPoint();
        targetPosition = endPoint;
    }
    void SetStartPoint()
    {
        startPoint = transform.position;
    }
    void SetEndPoint()
    {
        endPoint = transform.position + endPointCoords;
    }
    void Update()
    {
        direction = (targetPosition - transform.position).normalized; 
        if(movementIsTriggered)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = (targetPosition == startPoint) ? endPoint : startPoint;
            }
        }
        
    }
}
