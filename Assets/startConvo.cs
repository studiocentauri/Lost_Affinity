using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class startConvo : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<selfConvoPlayer>().StartDialogues();
        }
    }
}
