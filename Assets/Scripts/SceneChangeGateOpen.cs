using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGateOpen : MonoBehaviour
{
    public Animator animator;
    public string SceneName;
    private bool isOpen;
    Fade fade;

    void Start()
    {
        fade = GetComponent<Fade>();
        fade.FadeIn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collide");
            StartCoroutine(CheckGateOpen());
            collision.GetComponent<playermovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponentInChildren<Animator>().enabled = false;
        }
    }

    IEnumerator CheckGateOpen()
    {
        yield return new WaitForSeconds(0.01f);
        isOpen = animator.GetBool("IsOpen");
        if (isOpen)
        {
            fade.StartFadeOut();
            yield return new WaitForSeconds(fade.fadeDuration);
            Debug.Log("SceneChange");
            SceneManager.LoadScene(SceneName);
            yield return null;
        }
    }
}
