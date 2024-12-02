using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationTrigger : MonoBehaviour
{
    public PlatformOscillation platformOscillation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platformOscillation.movementIsTriggered = true;
        }
    }
}
