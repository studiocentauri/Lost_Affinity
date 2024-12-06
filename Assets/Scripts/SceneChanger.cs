using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName;
    public float delay = 0.5f;
    public Fade fade;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collide");
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        delay = fade.fadeDuration;
        fade.StartFadeOut();
        yield return new WaitForSeconds(delay);
        Debug.Log("SceneChange");
        SceneManager.LoadScene(SceneName);
        yield return null;
    }
}
