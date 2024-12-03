using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] pinkCar; // The car prefab array in order left, right, top, bottom to spawn

    private GameObject carPrefab; // The car prefab to spawn
    public float spawnInterval = 1f; // Time interval between spawns
    public Vector3[] spawnPositions; // Array of spawn positions

    public Vector2 intersectionPoint; // Intersection point defined in Inspector

    private int randomIndex;
    private int lastSpawnIndex = -1; // Index of the last spawn position

    private Vector2 direction; // Direction of movement


    void Start(){
        InvokeRepeating("SpawnCar",0f,spawnInterval);
    }

    void SpawnCar()
    {
        if (spawnPositions.Length == 0){
            Debug.LogError("No spawn positions defined for CarSpawner.");
            return;
        }

        do{
            randomIndex = Random.Range(0, spawnPositions.Length);
        } while (spawnPositions.Length > 1 && randomIndex == lastSpawnIndex);

        Vector3 spawnPosition = spawnPositions[randomIndex];
        lastSpawnIndex = randomIndex;

        if (spawnPosition.x < 0 && spawnPosition.y > 0){ // Left side
            direction = Vector2.right;
            carPrefab = pinkCar[0];
        }
        else if (spawnPosition.x > 0 && spawnPosition.y < 0){ // Right side
            direction = Vector2.left;
            carPrefab = pinkCar[1];
        }
        else if (spawnPosition.y > 0 && spawnPosition.x > 0){ // Top side
            direction = Vector2.down;
            carPrefab = pinkCar[2];
        }
        else if (spawnPosition.y < 0 && spawnPosition.x < 0){ // Bottom side
            direction = Vector2.up;
            carPrefab = pinkCar[3];
        }
        else 
            direction = Vector2.zero; // Fallback

        GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        CarController carController = newCar.GetComponent<CarController>();
        
        if (carController != null)
        {
            carController.SetDirection(direction); // Set direction for the new car
            
            // Set the intersection point for each car controller instance.
            carController.intersectionPoint = intersectionPoint;
        }
        else
        {
            Debug.LogError("CarController component not found in the car prefab.");
        }
    }
}