using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOn : MonoBehaviour
{
    public GameObject LaserObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (LaserObject != null)
            {
                LaserObject.SetActive(true);
            }
        }
    }
}
