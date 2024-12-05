using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject GateClosed;
    public GameObject gateOpen;

    private bool isPlayerInTrigger = false; // Track if the player is in the trigger area

    // Called when another collider enters the trigger
    void Start()
    {
        GateClosed.SetActive(true);
        gateOpen.SetActive(false);

    }
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
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // Check if Enter (Return) is pressed
        {
            if (GateClosed != null)
            {
                GateClosed.SetActive(false);
                gateOpen.SetActive(true);

            }
        }
    }
}
