using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherAudio : MonoBehaviour
{
    [SerializeField] weather localWeather;
    [SerializeField] AudioSource audioSource;
    [Header("Weather Audios")]
    [SerializeField] List<AudioClip> WeatherSoundsInOrder;
    [SerializeField] AudioClip currentAudio;
    [SerializeField] AudioClip playingAudio;

    void Update()
    {
        currentAudio = WeatherSoundsInOrder[localWeather.state % WeatherSoundsInOrder.Count];
        if(currentAudio != null)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(currentAudio);
                playingAudio = currentAudio;
            }
            else if(currentAudio != playingAudio)
            {
                audioSource.Stop();
                playingAudio = null;
            }
        }
        else 
        {
            audioSource.Stop();
            playingAudio = null;
        }
    }
}
