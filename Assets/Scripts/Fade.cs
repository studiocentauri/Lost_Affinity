using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public CanvasGroup fade;
    bool In = false;
    bool Out = false;
    public float FadeTime = 2;
    float speed;
    void Start()
    {
        speed = 1 / FadeTime;
    }

    void FixedUpdate()
    {
        if(In)
        {
            fade.alpha -= Time.fixedDeltaTime * speed;
            if (fade.alpha <= 0)
            {
                In = false;
            }
        }
        if (Out)
        {
            fade.alpha += Time.fixedDeltaTime * speed;
            if (fade.alpha >= 1)
            {
                Out = false;
            }
        }
    }

    public void FadeIn()
    {
        In = true;
    }

    public void FadeOut()
    {
        Out = true;
    }
}
