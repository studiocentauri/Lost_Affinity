using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGateOpen : MonoBehaviour
{
    public Animator animator;

    private bool isOpen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collide");
            StartCoroutine(CheckGateOpen());
            
        }
    }

    IEnumerator CheckGateOpen()
    {
        while (true)
        {
            isOpen = animator.GetBool("IsOpen");
            if (isOpen)
            {
                Debug.Log("SceneChange");
                SceneManager.LoadScene("LabScene2");
                yield return null;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
