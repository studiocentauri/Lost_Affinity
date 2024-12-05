using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to deactivate
    private bool isPlayerInTrigger = false; // Track if the player is in the trigger area

    // Called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            isPlayerInTrigger = true; // Set the flag to true
        }
    }

    // Called when another collider exits the trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            isPlayerInTrigger = false; // Reset the flag
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Return)) // Check if Enter (Return) is pressed
        {
            if (targetObject != null) // Ensure the targetObject is assigned
            {
                targetObject.SetActive(false); // Deactivate the target object
            }
        }
    }
}
