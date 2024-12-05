using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class i1j : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            o1.SetActive(false);
            o2.SetActive(true);
            
        }
        if(Input.GetKeyDown("1"))
            {
                o2.SetActive(false);
                o3.SetActive(true);
                
            }
            if(Input.GetKeyDown("f"))
                {
                    o3.SetActive(false);
                }
    }
}
