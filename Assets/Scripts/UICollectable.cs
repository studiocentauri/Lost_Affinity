using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollectable : MonoBehaviour
{
    public GameObject promptText;
    // Start is called before the first frame update public GameObject promptText;
    private bool isPlayerNearby = false;
    public GameObject colliders;

    void Start()
    {
        if (promptText != null)
        {
            promptText.SetActive(false); // Ensure the text is hidden initially
        }
        else
        {
            Debug.LogWarning("PromptText is not assigned!");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.I))
        {
            if (promptText != null)
            {
                promptText.SetActive(false);
            }


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (promptText != null)
            {
                promptText.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the object exiting the trigger is the player
        {
            isPlayerNearby = false;

            if (promptText != null)
            {
                promptText.SetActive(false); // Hide the "Press E to Talk" text
            }
            colliders.SetActive(false);
        }

    }
}
