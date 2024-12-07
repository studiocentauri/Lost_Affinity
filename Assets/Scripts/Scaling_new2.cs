using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling_new2 : MonoBehaviour
{
    public float max_scale = 1.25f;
    public float min_scale = 0.75f;
    public float time = 1.0f;

    private float[] scaleLevels; // Array to store the scale levels
    private int currentScaleIndex; // Index to track the current scale level
    private bool isScaling = false; // Flag to prevent overlapping scaling
    //bool big = false;

    void Start()
    {
        // Define the scale levels
        scaleLevels = new float[] { min_scale, max_scale };
        currentScaleIndex = 0; // Start at the middle scale (1.0x)
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isScaling)
        {
            // Move to the previous scale level, if possible
            if (currentScaleIndex > 0)
            {
                currentScaleIndex--;
                StartCoroutine(ScaleOverTime(scaleLevels[currentScaleIndex]));
            }
            // Move to the next scale level, if possible
            else if (currentScaleIndex < scaleLevels.Length - 1)
            {
                currentScaleIndex++;
                StartCoroutine(ScaleOverTime(scaleLevels[currentScaleIndex]));
            }
        }
    }

    IEnumerator ScaleOverTime(float targetScale)
    {
        isScaling = true;

        Vector3 initialScale = transform.localScale;
        Vector3 targetScaleVector = new Vector3(targetScale, targetScale, initialScale.z);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScaleVector, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScaleVector;
        isScaling = false;
    }
}

