using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collide");
        if (collision.CompareTag("NPC"))
        {
            
            animator.SetBool("GateOpen", true);
            animator.SetBool("GateClose", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            animator.SetBool("GateOpen", false);
            animator.SetBool("GateClose", true);
        }
    }
}
