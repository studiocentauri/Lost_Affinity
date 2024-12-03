using UnityEngine;

public class CarController : MonoBehaviour
{
    public float baseSpeed = 5f; // Base speed of the car
    public float minDistance = 1f; // Minimum distance for speed adjustments
    public float maxSpeed = 5f; // Maximum speed when far from other cars
    public float minSpeed = 0f; // Minimum speed (stopped)
    private float currentSpeed;
    private Vector2 direction; // Direction of movement
    public Vector2 intersectionPoint; // Intersection point defined in the Inspector

    // Method to set the direction of the car
    public void SetDirection(Vector2 spawnDirection)
    {
        direction = spawnDirection;
        currentSpeed = baseSpeed; // Initialize current speed
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        MoveCar();
        CheckForIntersection();
    }

    void MoveCar()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }

    void CheckForIntersection()
    {
        Collider2D[] nearbyCars = Physics2D.OverlapCircleAll(transform.position, 3f);
        
        foreach (var car in nearbyCars)
        {
            if (car != this.GetComponent<Collider2D>())
            {
                CarController otherCar = car.GetComponent<CarController>();
                if (otherCar != null)
                {
                    AdjustSpeedBasedOnDistance(otherCar);
                }
            }
        }
    }

    void AdjustSpeedBasedOnDistance(CarController otherCar)
    {
        float distance = Vector2.Distance(transform.position, otherCar.transform.position);
        
        // Determine relative direction
        bool isPerpendicular = Vector2.Dot(direction, otherCar.direction) == 0;

        if (isPerpendicular) // Perpendicular directions
        {
            HandlePerpendicularCollision(otherCar, distance);
        }
        else if(Vector2.Dot(direction, otherCar.direction)==1)// Parallel directions
        {
            HandleParallelCollision(otherCar, distance);
        }
    }

    void HandlePerpendicularCollision(CarController otherCar, float distance)
    {
        // Calculate distances to intersection based on current positions
        float thisDistanceToIntersection = GetDistanceToIntersection(transform.position);
        float otherDistanceToIntersection = otherCar.GetDistanceToIntersection(otherCar.transform.position);

        if (distance < minDistance) // Very close to another car
        {
            currentSpeed = minSpeed; // Stop completely
            otherCar.currentSpeed = minSpeed; // Also stop the other car for safety
        }
        else if (distance < minDistance * 2) // Close but not too close
        {
            if (thisDistanceToIntersection > otherDistanceToIntersection)
            {
                currentSpeed *= 0.5f; // Slow down if farther from intersection
            }
            else
            {
                currentSpeed = baseSpeed; // Maintain speed if closer to intersection
            }
        }
        else // Far enough from other cars
        {
            currentSpeed = baseSpeed; // Maintain base speed
            otherCar.currentSpeed = baseSpeed; // Ensure the other car can maintain its speed too
        }
    }

    void HandleParallelCollision(CarController otherCar, float distance)
    {
        if (distance < minDistance) // Very close to another car in the same lane
        {
            currentSpeed = minSpeed; // Stop completely
            otherCar.currentSpeed = Mathf.Max(minSpeed, otherCar.currentSpeed - 1f); // Slow down the following car to avoid collision
        }
        else if (distance < minDistance * 2) // Close but not too close in the same lane
        {
            currentSpeed = Mathf.Lerp(minSpeed, baseSpeed, (distance - minDistance) / minDistance); // Gradually increase speed
            
            if (otherCar.currentSpeed > currentSpeed)
                otherCar.currentSpeed = currentSpeed; // Ensure the following car does not exceed the speed of the leading car
        }
        else // Far enough from other cars in the same lane
        {
            currentSpeed = baseSpeed; // Maintain base speed
            otherCar.currentSpeed = baseSpeed; // Ensure the following car can maintain its speed too
        }
    }

    private float GetDistanceToIntersection(Vector2 position)
    {
        return Vector2.Distance(position, intersectionPoint); // Distance from car's position to intersection point
    }
}