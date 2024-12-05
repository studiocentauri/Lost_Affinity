using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName;
    public float delay = 1f;
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
        yield return new WaitForSeconds(delay);
        Debug.Log("SceneChange");
        SceneManager.LoadScene(SceneName);
        yield return null;
    }
}
