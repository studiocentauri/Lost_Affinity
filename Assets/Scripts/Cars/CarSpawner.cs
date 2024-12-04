using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float destroyTime;
    public GameObject[] pinkCar; // The car prefab array in order left, right, top, bottom to spawn
    public GameObject[] lightBlueCar; // The car prefab array in order left, right, top, bottom to spawn
    public GameObject[] greenCar; // The car prefab array in order left, right, top, bottom to spawn
    public GameObject[] darkBlueCar; // The car prefab array in order left, right, top, bottom to spawn
    private GameObject[][] cars;

    private GameObject[] currentCars; // The current car prefab array to spawn

    private GameObject carPrefab; // The car prefab to spawn
    public float spawnInterval = 1f; // Time interval between spawns
    public Vector3[] spawnPositions; // Array of spawn positions

    public Vector2 intersectionPoint; // Intersection point defined in Inspector

    private int randomIndex;
    private int lastSpawnIndex = -1; // Index of the last spawn position

    private Vector2 direction; // Direction of movement


    void Start(){
        InvokeRepeating("SpawnCar",0f,spawnInterval);
        cars = new GameObject[][] {pinkCar, lightBlueCar, greenCar, darkBlueCar};
    }

    void SpawnCar()
    {
        currentCars = cars[Random.Range(0, cars.Length)];
        if (spawnPositions.Length == 0){
            Debug.LogError("No spawn positions defined for CarSpawner.");
            return;
        }

        do{
            randomIndex = Random.Range(0,spawnPositions.Length);
        }while (spawnPositions.Length > 1 && randomIndex == lastSpawnIndex);

        Vector3 spawnPosition = spawnPositions[randomIndex];
        lastSpawnIndex = randomIndex;

        if (spawnPosition.x < intersectionPoint.x && spawnPosition.y > intersectionPoint.y){ // Left side
            direction = Vector2.right;
            carPrefab = currentCars[0];
        }
        else if (spawnPosition.x > intersectionPoint.x && spawnPosition.y < intersectionPoint.y){ // Right side
            direction = Vector2.left;
            carPrefab = currentCars[1];
        }
        else if (spawnPosition.y > intersectionPoint.y && spawnPosition.x > intersectionPoint.x){ // Top side
            direction = Vector2.down;
            carPrefab = currentCars[2];
        }
        else if (spawnPosition.y < intersectionPoint.y && spawnPosition.x < intersectionPoint.x){ // Bottom side
            direction = Vector2.up;
            carPrefab = currentCars[3];
        }
        else 
            direction = Vector2.zero; // Fallback

        GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        CarController carController = newCar.GetComponent<CarController>();
        
        if (carController != null)
        {
            carController.deathDelay = destroyTime;
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