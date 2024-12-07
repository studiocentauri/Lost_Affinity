using System;
using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage; // Assign this in the inspector with a full-screen UI Image.
    public float fadeDuration = 1f; // Duration of the fade.

    private void Start()
    {
        // Ensure the fadeImage is fully opaque at the start
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        StartCoroutine(FadeIn()); // Start with a fade-in effect.
    }

    public void StartFadeOut()
    {
        fadeImage.gameObject.SetActive(true); // Enable the fadeImage before the fade-out effect.
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f); // Ensure fully transparent at the end.
        fadeImage.gameObject.SetActive(false); // Disable the fadeImage after the fade-in effect.
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f); // Ensure fully opaque at the end.
    }
}
