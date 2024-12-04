using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileWeather : MonoBehaviour
{
    [SerializeField] weather localWeather;
    [SerializeField] List<Tilemap> sunny;
    [SerializeField] List<Tilemap> rain;
    [SerializeField] List<Tilemap> autumn;
    [SerializeField] List<Tilemap> snow;
    List<List<Tilemap>> weathers;
    bool transitionRunning;
    float time; int state;
    void Start()
    {
        state = 0;
        weathers = new List<List<Tilemap>>();
        for(int i = 0; i<sunny.Count; i++)
        {
            sunny[i].color = new Color(1,1,1,1);
            rain[i].color = new Color(1,1,1,0);
            snow[i].color = new Color(1,1,1,0);
            autumn[i].color = new Color(1,1,1,0);
        }
        weathers.Add(sunny);
        weathers.Add(rain);
        weathers.Add(snow);
        weathers.Add(autumn);
    }
    void Update()
    {
        if(localWeather.isInTransit && !transitionRunning)
        {
            transitionRunning = true;
            time = 0f;
            state += 1;
            state = state % weathers.Count;
        }
        else if(!localWeather.isInTransit && transitionRunning)
        {
            transitionRunning = false;
            for(int i=0; i<sunny.Count; i++)
            {
                weathers[state][i].color = new Color(1,1,1,1);
                weathers[(state-1+weathers.Count)%weathers.Count][i].color = new Color(1,1,1,0);
            }
        }
        if(transitionRunning)
        {
            time += Time.deltaTime;
            for(int i=0; i<sunny.Count; i++)
            {
                weathers[state][i].color = new Color(1,1,1,time / localWeather.transitTime);
                weathers[(state-1+weathers.Count)%weathers.Count][i].color = new Color(1,1,1,1 - time / localWeather.transitTime);
            }
        }
    }
}
