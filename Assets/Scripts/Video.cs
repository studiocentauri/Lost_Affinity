using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    VideoPlayer vp;
    public GameObject text;
    public Fade fade;

    //public Animator transition;
    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Submit") != 0 && vp.frame < 760)
        {
            Debug.Log(vp.frame);
            vp.frame = 760;
        }
        if (vp.frame > 760)
        {
            text.SetActive(false);
        }

        if (vp.frame > 760)
        {
            StartCoroutine(LoadLevel());
        }

    }

    IEnumerator LoadLevel()
    {
        fade.FadeOut();
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level-1 1");
    }
}
