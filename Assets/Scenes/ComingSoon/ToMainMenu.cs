using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<Fade>();
        Invoke("StartFade", 3f);
    }

    void StartFade()
    {
        fade.StartFadeOut();
        Invoke("ChangeScene", fade.fadeDuration);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
