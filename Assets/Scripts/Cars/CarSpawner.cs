using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // The car prefab to spawn
    public float spawnInterval = 1f; // Time interval between spawns
    public Vector3[] spawnPositions; // Array of spawn positions

    public Vector2 intersectionPoint; // Intersection point defined in Inspector

    private int randomIndex;
    Quaternion[] spawnRotations = {
            Quaternion.Euler(0, 0, 0),  // Left side
            Quaternion.Euler(0, 0, -180), // Right side
            Quaternion.Euler(0, 0, 90), // Bottom side
            Quaternion.Euler(0, 0, -90)    // Top side
    };
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

        //Quaternion spawnRotation = spawnRotations[randomIndex];
        //GameObject newCar = Instantiate(carPrefab, spawnPosition, spawnRotation);
        GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        //get first child
        GameObject car = newCar.transform.GetChild(0).gameObject;
        car.transform.Rotate(new Vector3(0, 0, spawnRotations[randomIndex].eulerAngles.z), Space.Self);
        //newCar.transform.eulerAngles+=new Vector3(0, 0, spawnRotations[randomIndex].eulerAngles.z);
        CarController carController = newCar.GetComponent<CarController>();
        
        if (carController != null)
        {
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
        else
        {
            Debug.LogError("CarController component not found in the car prefab.");
        }
    }
}