using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // The car prefab to spawn
    public float spawnInterval = 1.0f; // Time interval between spawns
    public Vector3[] spawnPositions; // Array of spawn positions

    public Vector2 intersectionPoint; // Intersection point defined in Inspector

    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, spawnInterval);
    }

    void SpawnCar()
    {
        if (spawnPositions.Length == 0)
        {
            Debug.LogWarning("No spawn positions defined for CarSpawner.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomIndex];

        GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        
        CarController carController = newCar.GetComponent<CarController>();
        
        if (carController != null)
        {
            Vector2 direction;
            
            // Set direction based on spawn position
            if (spawnPosition.x < 0 && spawnPosition.y > 0) // Left side
                direction = Vector2.right;
            else if (spawnPosition.x > 0 && spawnPosition.y < 0) // Right side
                direction = Vector2.left;
            else if (spawnPosition.y < 0 && spawnPosition.x < 0) // Bottom side
                direction = Vector2.up;
            else if (spawnPosition.y > 0 && spawnPosition.x > 0) // Top side
                direction = Vector2.down;
            else 
                direction = Vector2.zero; // Fallback
            
            carController.SetDirection(direction); // Set direction for the new car
            
            // Set the intersection point for each car controller instance.
            carController.intersectionPoint = intersectionPoint;
        }
    }
}