using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [Header("End Positions")]
    public Vector2 positionA;
    public Vector2 positionB;

    [Header("Movement Parameters")]
    public float speed = 2f; // Speed of movement
    public float waitTime = 0.5f; // Time to wait at each position in seconds

    private Vector2 currentTarget;
    private bool isWaiting;

    private void Start()
    {
        //currentTarget = positionB;
    }

    private void Update()
    {
        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, currentTarget) < 0.01f)
            {
                StartCoroutine(SwitchTarget());
            }
        }
    }

    private System.Collections.IEnumerator SwitchTarget()
    {
        isWaiting = true;

        // Wait for the specified wait time
        yield return new WaitForSeconds(waitTime);

        // Switch the target
        currentTarget = currentTarget == positionA ? positionB : positionA;
        isWaiting = false;
    }
}
