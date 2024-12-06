using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    [SerializeField] bool playerAttached;
    Transform playerTransform;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playermovement>().isAttachedToPlatform = true;
            playerAttached = true;
            playerTransform = other.transform;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playermovement>().isAttachedToPlatform = false;
            playerAttached = false;
            playerTransform = null;
        }
    }
    void Update()
    {
        if(playerAttached)
        {
           playerTransform.position = playerTransform.position + GetComponent<PlatformOscillation>().direction * GetComponent<PlatformOscillation>().speed * Time.deltaTime;
        }
    }
}
