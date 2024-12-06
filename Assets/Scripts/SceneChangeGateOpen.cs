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

        }
    }

    IEnumerator CheckGateOpen()
    {
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
