using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weather : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> weatherStates;
    [SerializeField] float transitTime;
    [SerializeField] float weatherTime;// Note that transit time must be less than weatherTime
    float time = 0f;
    int state = 0;
    void Update()
    {
        time += Time.deltaTime;
        if(time >= weatherTime)
        {
            time = 0;
            weatherStates[state].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);;
            Invoke("Inactive",transitTime);
            state++; state = state % weatherStates.Count;
            weatherStates[state].gameObject.SetActive(true);
            weatherStates[state].Clear();
            weatherStates[state].Play();
        }
    }
    void Inactive()
    {
        weatherStates[(state+weatherStates.Count-1)%weatherStates.Count].gameObject.SetActive(false);
    }
}
