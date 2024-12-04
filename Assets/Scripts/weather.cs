using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weather : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> weatherStates;
    public float transitTime;
    public float weatherTime;// Note that transit time must be less than weatherTime
    public float time = 0f;
    public bool isInTransit;
    int state = 0;
    void Update()
    {
        time += Time.deltaTime;
        if(time >= weatherTime)
        {
            isInTransit = true;
            time = 0;
            weatherStates[state].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);;
            Invoke("Inactive",transitTime);
            state++; state = state % weatherStates.Count;
            weatherStates[state].gameObject.SetActive(true);
            weatherStates[state].Clear();
            weatherStates[state].Play();
            Debug.Log(state);
        }
    }
    void Inactive()
    {
        isInTransit=false;
        weatherStates[(state+weatherStates.Count-1)%weatherStates.Count].gameObject.SetActive(false);
    }
}
