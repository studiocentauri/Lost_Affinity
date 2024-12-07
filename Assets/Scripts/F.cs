using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    public GameObject panel;
    public GameObject continued;
    // Update is called once per frame
    void Start(){
        continued.SetActive(false);
    }
    void Update()
    {
        
            if(panel.activeSelf){
                continued.SetActive(true);
            }
        if(!panel.activeSelf){ 
            continued.SetActive(false);
        }

    }
}
