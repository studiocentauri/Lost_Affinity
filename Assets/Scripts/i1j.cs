using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class i1j : MonoBehaviour
{
    
    public GameObject o2;
    public GameObject o3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
            {
                
                o3.SetActive(true);
                o2.SetActive(false);
            }
            if(Input.GetKeyDown("f"))
                {
                    o3.SetActive(false);
                }
    }
}
