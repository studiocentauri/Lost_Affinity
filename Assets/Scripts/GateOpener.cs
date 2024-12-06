using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    public Animator animator;
    Fade fade;

    void Start()
    {
        fade = GetComponent<Fade>();
        fade.FadeIn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collide");
        if (collision.CompareTag("NPC"))
        {
            
            animator.SetBool("GateOpen", true);
            animator.SetBool("GateClose", false);
        }

        if(collision.CompareTag("Player"))
        {
            StartCoroutine(CheckGateOpen());
            collision.GetComponent<playermovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponentInChildren<Animator>().enabled = false;
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

    IEnumerator CheckGateOpen()
    {
        bool isOpen = animator.GetBool("GateOpen");
        if (isOpen)
        {
            Invoke("ColliderOff", 0.25f);
            fade.StartFadeOut();
            yield return new WaitForSeconds(fade.fadeDuration);
            Debug.Log("SceneChange");
            SceneManager.LoadScene("Level-2 1");
            yield return null;
        }
    }

    void ColliderOff()
    {
        animator.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
