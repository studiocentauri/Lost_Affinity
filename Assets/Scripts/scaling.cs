using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float max_scale = 1.25f;
    public float min_scale = 0.75f;
    public float time = 1.0f;
    Vector2 scale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scale = transform.localScale;
        if(Input.GetKeyDown(KeyCode.F)){
            scale.x = scale.x - (scale.x - min_scale) * Time.deltaTime / time;
            scale.y = scale.y - (scale.y - min_scale) * Time.deltaTime / time;
            if(scale.x < min_scale){
                scale.x = min_scale;
            }
            if(scale.y < min_scale){
                scale.y = min_scale;
            }
            transform.localScale = scale;
        }
        if(Input.GetKeyDown(KeyCode.G)){
            scale.x = scale.x + (max_scale - scale.x) * Time.deltaTime / time;
            scale.y = scale.y + (max_scale - scale.y) * Time.deltaTime / time;
            if(scale.x > max_scale){
                scale.x = max_scale;
            }
            if(scale.y > max_scale){
                scale.y = max_scale;
            }
            transform.localScale = scale;
        }
    }
}
