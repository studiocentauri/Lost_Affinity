using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    public GameObject promptText;
    private bool isPlayerNearby = false;
    public GameObject colliders;
    public GameObject Temp;
    public string[] key;

    void Start()
    {
        if (promptText != null)
        {
            promptText.SetActive(false); // Ensure the text is hidden initially
        }
      
    }

    void Update()
    {
        foreach(string k in key){
            if (isPlayerNearby && Input.GetKeyDown(k))
            {
                // Hide the text after pressing E
                if (promptText != null)
                {
                    promptText.SetActive(false);
                }
                if(Temp!=null){
                    Temp.SetActive(false);
                }
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
            if(colliders != null)
            {
                colliders.SetActive(false);
            }
        }

    }
}
