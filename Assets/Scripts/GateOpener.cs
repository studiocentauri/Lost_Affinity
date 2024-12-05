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
            fade.FadeOut();
            yield return new WaitForSeconds(fade.FadeTime);
            Debug.Log("SceneChange");
            SceneManager.LoadScene("Level-2");
            yield return null;
        }
    }
}
