using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Set the slider's value to the current volume
        volumeSlider.value = audioSource.volume;

        // Add a listener to the slider to call the OnVolumeChange method when the value changes
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    void OnVolumeChange(float value)
    {
        // Change the volume of the audio source
        audioSource.volume = value;
    }
}
