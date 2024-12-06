using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerPlayer : MonoBehaviour
{
    public Animator animator;
    public Collider2D collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", true);
            animator.SetBool("IsClose", false);
            collider.enabled = false;
        }
    }
}
